using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePickUpAction : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int GridPosition, TileMapReadController tileMapReadController, Item item)
    {
        tileMapReadController.cropsManager.PickUp(GridPosition);
        tileMapReadController.objectManager.PickUp(GridPosition);
        return true;
    }
}
