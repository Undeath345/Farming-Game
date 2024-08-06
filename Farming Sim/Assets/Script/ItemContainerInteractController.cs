using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{
    ItemContainer targetItemContainer;
    InventoryController inventoryController;
    [SerializeField] ItemContainerPanel itemContainerPanel;

    public void Open(ItemContainer itemContainer)
    {
        targetItemContainer = itemContainer;
        itemContainerPanel.inventory = targetItemContainer;
        itemContainerPanel.gameObject.SetActive(true);
    }
    public void Close()
    {
        itemContainerPanel.gameObject.SetActive(false);

    }
}
