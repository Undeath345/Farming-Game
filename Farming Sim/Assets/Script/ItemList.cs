using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/ItemDataBase")]
public class ItemList : ScriptableObject
{
    public List<Item> items;
}
