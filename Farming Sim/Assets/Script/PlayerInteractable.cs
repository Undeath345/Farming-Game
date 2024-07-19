using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;

    [SerializeField] HighlightController highlightController;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }
    private void Check()
    {
        Vector2 postision = rgbd2d.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(postision, sizeOfInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                break;
            }

            highlightController.Hide();
        }
    }
    private void Interact()
    {
        Vector2 postision = rgbd2d.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(postision, sizeOfInteractableArea);
        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
