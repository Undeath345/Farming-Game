using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class PlaceObjectReferenceManager : MonoBehaviour
{
    public PlaceableObjectManager placeableObjectManager;

    public void Place(Item item, Vector3Int pos)
    {
        if (placeableObjectManager == null)
        {
            Debug.LogWarning("No placeableObjectManager reference detected");
            return;
        }
        placeableObjectManager.Place(item, pos);
    }
    public void PickUp(Vector3Int gridPosition)
    {
        if (placeableObjectManager == null)
        {
            Debug.LogWarning("No placeableObjectManager reference detected");
            return;
        }
        placeableObjectManager.Check(gridPosition);
    }
    public bool Check(Vector3Int pos)
    {
        if (placeableObjectManager == null)
        {
            Debug.LogWarning("No placeableObjectManager reference detected");
            return false;
        }
        return placeableObjectManager.Check(pos);
    }
}