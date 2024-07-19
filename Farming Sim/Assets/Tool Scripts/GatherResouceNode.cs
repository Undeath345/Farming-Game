using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


[CreateAssetMenu(menuName = " Data/Tool action/Gather Resource Node")]
public class GatherResouceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    public override bool OnApply(Vector2 WorldPoint)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(WorldPoint, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.gameObject.GetComponent<ToolHit>();
            if (hit != null)
            {

                hit.Hit();
                break;
            }
        }
        return false;
    }
}
