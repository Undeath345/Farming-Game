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
public class ItemConventorInteract : Interactable, IPersistants 
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
    [SerializeField] int producedItemCount = 1;
    
    [SerializeField] float timeToProcess;
    ItemConvertorData data;


    private void Start()
    {
        if (data == null)
        {
            data = new ItemConvertorData();
        }
    }
    public override void Interact(Character character)
    {
        if(GameManager.Instance.dragAndDropController.Check(convertableItem)) 
        {
            StartItemProcessing();
        }
        if(data.itemSlot.item != null && data.timer < 0f)
        {
            GameManager.Instance.inventoryContainer.Add(data.itemSlot.item, data.itemSlot.count);
            data.itemSlot.Clear();
        }
    }
    private void StartItemProcessing()
    {
        data.itemSlot.Copy(GameManager.Instance.dragAndDropController.itemSlot);
        data.itemSlot.count = 1;
        GameManager.Instance.dragAndDropController.removeItem();
        data.timer = 0;

    }
    private void Update()
    {
        if(data.itemSlot == null)
        {
            return;
        }
        if( data.timer > 0f)
        {
            data.timer -= Time.deltaTime;
            if(data.timer <= 0f) 
            {
  
            }
        }
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
