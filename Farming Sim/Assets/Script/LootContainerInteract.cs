using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] ItemContainer ItemContainer;

    private void Start()
    {
        if (ItemContainer == null)
        {
            Init();
        }
    }

    private void Init()
    {
            ItemContainer = (ItemContainer)ScriptableObject.CreateInstance(typeof(ItemContainer));
            ItemContainer.Init();
    }

    public override void Interact(Character character)
    {
        if (opened == false)
        {
            Open(character);
        }
        else 
        {
            Close(character);
        }
    }
    public void Open(Character character)
    {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);

            character.GetComponent<ItemContainerInteractController>().Open(ItemContainer, transform);
    }
    public void Close(Character character)
    {
            opened = true;
            closedChest.SetActive(true);
            openedChest.SetActive(false);

            character.GetComponent<ItemContainerInteractController>().Close();
    }

    [Serializable]
    public class SaveLootItemData
    {
        public int itemId;
        public int count;

        public SaveLootItemData(int id, int c)
        {
            itemId = id;
            count = c;
        }
    }

    [Serializable]
    public class ToSave
    {
        public List<SaveLootItemData> itemDatas;
    }

    public string Read()
    {
        ToSave toSave = new ToSave();

        for(int i = 0; i < ItemContainer.slots.Count; i++)
        {
            if (ItemContainer.slots[i].item == null)
            {
                toSave.itemDatas.Add(new SaveLootItemData(-1, 0));
            }
            else
            {
                toSave.itemDatas.Add(new SaveLootItemData(
                        ItemContainer.slots[i].item.id,
                        ItemContainer.slots[i].count
                        )
                    );
            }
        }

        return JsonUtility.ToJson( toSave );
    }

    public void Load(string jsonString)
    {
        if( jsonString == "" || jsonString == "{}" || jsonString == null) { return; }
        if(ItemContainer == null)
        {
            Init();
        }
        ToSave toLoad = JsonUtility.FromJson<ToSave>( jsonString );
        for(int i = 0;i < ItemContainer.slots.Count; i++)
        {
            if (toLoad.itemDatas[i].itemId == -1)
            {
                ItemContainer.slots[i].Clear();
            }
            else
            {
                ItemContainer.slots[i].item = GameManager.Instance.itemDB.items[toLoad.itemDatas[i].itemId];
                ItemContainer.slots[i].count = toLoad.itemDatas[i].count;
            }
        }
    }
}
