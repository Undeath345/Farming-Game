using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ToolAction/Seed Tile")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int GridPosition, TileMapReadController tileMapReadController)
    {
        if(tileMapReadController.cropsManager.Check(GridPosition) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Seed(GridPosition);

        return true;
    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
