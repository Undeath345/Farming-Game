using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;

public class ToolsCharacterController : MonoBehaviour
{
    /*PlayerController character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapMapController tileMapReadcontroller;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;

    Vector3Int selectTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0)
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadcontroller.GetGridPosition(Input.mousePosition, true);

    }
    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }
    
    private void UserToolWorld()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach(Collider2D collider in colliders)
        {
            ToolHit hit = collider.gameObject.GetComponent<ToolHit>();
            if (hit != null)
            {

                hit.Hit();
                break;
            }
        }
    }
    private void UseToolGrid()
    {
        if (selectable)
        {
            cropsManager.Plow(Vector2Int)selectedTile);
        }
    }*/
}
