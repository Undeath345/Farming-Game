using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float areaSize = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer s;
    public GameObject love;
    public Transform vt;
    bool l = false;
    private Vector2 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(MoveChicken());
        s = GetComponent<SpriteRenderer>();
    }

    void Update()
    {       
           //  transform.position = Vector3.MoveTowards(transform.position,movement,moveSpeed*Time.deltaTime);
             rb.velocity = movement * moveSpeed;
            animator.SetFloat("Speed", rb.velocity.magnitude);
            // Vector2 newPos = Vector2.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //rb.MovePosition(newPos);
           // Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
           // animator.SetFloat("Speed", direction.magnitude);
            if (movement.x < 0)
            {
                s.flipX = true;
            }
            else if (movement.x > 0)
            {
                s.flipX = false;
            }        
    }

    IEnumerator MoveChicken()
    {
        while (true)
        {
            if (l)
            {
                yield return null;
            }
            else
            {
                // Random position within the defined area
                  Vector2 newPos = new Vector2(Random.Range(-areaSize, areaSize), Random.Range(-areaSize, areaSize));
                 Vector2 direction = (newPos - (Vector2)transform.position).normalized;
                movement = direction;
                //targetPosition = new Vector2(Random.Range(-areaSize, areaSize), Random.Range(-areaSize, areaSize));
                // Randomly decide whether to walk or idle
                bool isWalking = Random.Range(0, 2) == 1;
                if (isWalking)
                {
                    animator.SetBool("an", true);
                    animator.SetBool("dichuyen", false);
                    moveSpeed = 2f;  // Set walking speed
                }
                else
                {
                    animator.SetBool("dichuyen", true);
                    animator.SetBool("an", false);
                    moveSpeed = 0f;  // Idle, no movement
                }

                // Wait for a random time before changing direction
                float waitTime = Random.Range(1f, 3f);
                yield return new WaitForSeconds(waitTime);
            }
        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "chicken")
        { 
            StartCoroutine(Love());
        }
    }
    IEnumerator Love()
    {
        l = true;
            GameObject g = Instantiate(love, vt.position, Quaternion.identity);
            moveSpeed = 0;
            animator.SetBool("dichuyen", false);
            animator.SetBool("love", true);
        Destroy(g,3f);
        yield return new WaitForSeconds(4f);
        animator.SetBool("love", false);        
        l= false;
    }
}
