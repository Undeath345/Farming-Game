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
    }

    public void Place(Item item, Vector3Int positionOnGrid)
    {
        GameObject go = Instantiate(item.itemPrefab);
        Vector3 position = targetTilemap.CellToWorld(positionOnGrid) + targetTilemap.cellSize/2;
        position -= Vector3.forward * 0.1f;
        go.transform.position = position;
        Po.placeableOjects.Add(new PlaceableObject(item, go.transform, positionOnGrid));
       
    }
}
