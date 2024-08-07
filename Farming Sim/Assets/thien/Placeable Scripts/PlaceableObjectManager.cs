using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class PlaceableObjectManager : MonoBehaviour
{

    [SerializeField] PlaceableObjectContainer Po; 
    [SerializeField] Tilemap targetTilemap;

    private void Start()
    {
        GameManager.Instance.GetComponent< PlaceObjectReferenceManager>().placeableObjectManager = this;
        VisualizeMap();
    }
    private void OnDestroy()
    {
        for (int i  = 0; i < Po.placeableOjects.Count; i++)
        {
            Po.placeableOjects[i].targetObject = null;
        }
    }
    private void VisualizeMap()
    {
        for(int i = 0; i < Po.placeableOjects.Count; i++)
        {
            VisualizeItem(Po.placeableOjects[i]);
        }
    }
    public void VisualizeItem(PlaceableObject placeableObject)
    {
        GameObject go = Instantiate(placeableObject.placedItem.itemPrefab);
        Vector3 position = targetTilemap.CellToWorld(placeableObject.positionOnGrid) + targetTilemap.cellSize/2;
        position -= Vector3.forward * 0.1f;
        go.transform.position = position;
        placeableObject.targetObject = go.transform;
    }
    public void Place(Item item, Vector3Int positionOnGrid)
    {
        PlaceableObject placeableObject = new PlaceableObject(item,positionOnGrid);
        VisualizeItem(placeableObject);
        Po.placeableOjects.Add(placeableObject);
    }

}
