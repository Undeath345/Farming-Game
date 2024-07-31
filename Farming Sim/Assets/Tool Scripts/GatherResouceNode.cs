using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum ResourceNodeType
{
    Undefined,
    Tree,
    Ore
}

[CreateAssetMenu(menuName = " Data/Tool action/Gather Resource Node")]
public class GatherResouceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] List<ResourceNodeType> canHitNodeOfType;
    public override bool OnApply(Vector2 WorldPoint)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(WorldPoint, sizeOfInteractableArea);
        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.gameObject.GetComponent<ToolHit>();
            if (hit != null)
            {
                if(hit.CanBeHit(canHitNodeOfType) == true)
                {
                    hit.Hit();
                    return true;
                }
            }
        }
        return false;
    }
}
