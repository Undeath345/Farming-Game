using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConventorInteract : MonoBehaviour
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
    
    ItemSlot itemSlot;
    [SerializeField] float timeToProcess;
    float timer;
}
