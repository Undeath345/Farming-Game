using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController character;
    Rigidbody2D rgbd2d;
    ToolBarController toolBarController;
    Animator animator;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadcontroller;
    [SerializeField] float maxDistance = 1.5f;
<<<<<<< HEAD
    [SerializeField] IconHighLight iconHighLight;
=======
    [SerializeField] ToolAction onTilePickUp;
>>>>>>> 7659e262b2b6d73bab44e8ab4b29b6d5bd821adc

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
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
        iconHighLight.CanSelect = selectable;
    }
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
        iconHighLight.targetPosition = selectedTilePosition;
    }
    
    private bool UseToolWorld()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolBarController.GetItem;
        if(item == null)
        {
            return false;
        }

        if(item.onAction == null)
        {
            return false;
        }

        animator.SetTrigger("act");
        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.Instance.inventoryContainer);
            }
        }

        return complete;
    }
    private void UseToolGrid()
    {
       if(selectable == true)
        {
            Item item = toolBarController.GetItem;
            if(item == null)
            {
                PickUpTile();
                return;
            }

            if(item.onTileMapAction == null)
            {
                return;
            }
            animator.SetTrigger("act");
            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadcontroller, item);

            if(complete == true)
            {
                if(item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.Instance.inventoryContainer);
                }
            }
        }
    }

<<<<<<< HEAD
=======
    private void PickUpTile()
    {
        if(onTilePickUp == null)
        {
            return;
        }
        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadcontroller, null);
    }
>>>>>>> 7659e262b2b6d73bab44e8ab4b29b6d5bd821adc
}
