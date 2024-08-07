using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    public CropsManager cropsManager;
    public PlaceObjectReferenceManager objectManager;
    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;

        if (mousePosition)
        {
            worldPosition = Camera.main.WorldToScreenPoint(position);
        }
        else
        {
            worldPosition = position;
        }

        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);

        return gridPosition;
    }
    public TileBase GetTileBase(Vector3Int gridPosition)
    {

        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }
}
