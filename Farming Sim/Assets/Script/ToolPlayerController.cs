using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPlayerController : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    void Start()
    {
        player = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Usetool();
        }
    }
    private void Usetool()
    {
        Vector2 postision = rgbd2d.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(postision, sizeOfInteractableArea);
        foreach ( Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if ( hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
