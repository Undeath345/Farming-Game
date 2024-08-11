using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ItemConvertorData
{
    public ItemSlot itemSlot;
    public float timer;

    public ItemConvertorData()
    {
        itemSlot = new ItemSlot();
    }
}
[RequireComponent(typeof(TimeAgent))]
public class ItemConventorInteract : Interactable, IPersistants 
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
    [SerializeField] int producedItemCount = 1;
    
    [SerializeField] int timeToProcess = 5;
    ItemConvertorData data;


    private void Start()
    {
        TimeAgent timeAgent = GetComponent<TimeAgent>();
        timeAgent.onTimeTick += ItemConvertProcess;
        if (data == null)
        {
            data = new ItemConvertorData();
        }
    }
    private void ItemConvertProcess()
    {
        if (data.itemSlot == null)
        {
            return;
        }
        if (data.timer > 0f)
        {
            data.timer -= 1;
            if (data.timer <= 0)
            {
                CompleteItemConversion();
            }
        }
    }
    public override void Interact(Character character)
    {
        if (data.itemSlot.item == null)
        {
            if (GameManager.Instance.dragAndDropController.Check(convertableItem))
            {
                StartItemProcessing(GameManager.Instance.dragAndDropController.itemSlot);
                return;
            }
            ToolBarController toolBarController = character.GetComponent<ToolBarController>();
            if (toolBarController == null) { return; }

            ItemSlot itemslot = toolBarController.GetItemSlot;
            if (itemslot.item == convertableItem)
            {
                StartItemProcessing(itemslot);
                return;
            }
        }
        if(data.itemSlot.item != null && data.timer <= 0)
        {
            GameManager.Instance.inventoryContainer.Add(data.itemSlot.item, data.itemSlot.count);
            data.itemSlot.Clear();
        }
    }
    private void StartItemProcessing(ItemSlot toProcess)
    {
        data.itemSlot.Copy(GameManager.Instance.dragAndDropController.itemSlot);
        data.itemSlot.count = 1;
        if(toProcess.item.stackable) 
        {
            toProcess.count -= 1;
            if(toProcess.count < 0)
            {
                toProcess.Clear();
            }
        }
        else {
            toProcess.Clear();
        }
        data.timer = 0;

    }
    private void CompleteItemConversion()
    {
        data.itemSlot.Clear();
        data.itemSlot.Set(producedItem, producedItemCount);
    }

    public string Read()
    {
        return JsonUtility.ToJson(data);
    }

    public void Load(string jsonString)
    {
        data = JsonUtility.FromJson<ItemConvertorData>(jsonString);
    }
}
