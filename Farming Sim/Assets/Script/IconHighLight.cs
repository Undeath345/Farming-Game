using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IconHighLight : MonoBehaviour
{
    public Vector3Int cellPosition;
    public Vector3 targetPosition;
    [SerializeField] Tilemap targetTilemap;
    SpriteRenderer spriteRenderer;

    bool canSelect;
    bool show;

    public bool CanSelect
    {
        set
        {
            canSelect = value;
            gameObject.SetActive(canSelect && show);
        }
    }
    public bool Show
    {
        set
        {
            show = value;
            gameObject.SetActive(canSelect && show);
        }
    }
    void Start()
    {
        targetPosition = targetTilemap.CellToWorld(cellPosition);
        transform.position = targetPosition + targetTilemap.cellSize/2;
    }
    internal void Set(Sprite icon)
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = icon;
    }
}
