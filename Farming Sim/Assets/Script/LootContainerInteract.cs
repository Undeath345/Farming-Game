using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] ItemContainer ItemContainer;
    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);

            character.GetComponent<ItemContainerInteractController>().Open(ItemContainer);

        }
        else 
        {
            opened = true;
            closedChest.SetActive(true);
            openedChest.SetActive(false);

            character.GetComponent<ItemContainerInteractController>().Close();
        }
    }
}

