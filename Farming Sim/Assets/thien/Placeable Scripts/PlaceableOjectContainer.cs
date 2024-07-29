using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlaceableOject
{
    public Item placedItem;
    public Transform targetOject;
    public Vector3Int positionOnGrid;
}
[CreateAssetMenu(menuName ="Data/Placeable Object Container")]
public class PlaceableOjectContainer : ScriptableObject
{
    public List<GameObject> placeableOjects;
}
