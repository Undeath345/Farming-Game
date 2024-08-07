using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public string tag;
    public float moveSpeed = 2f;
    public float areaSize = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer s;
    private Collider2D collider;
    public GameObject love;
    public Transform vt;
    public bool l = false;
    private Vector2 targetPosition;
    public Vector2 khuvuc = new Vector2(0,0);
    public GameObject egg;
    //public GameObject vitri;
    public bool Object = false;
    public bool chicken = false;
    private DayTimeController eventController;
    bool sleeping = false;
    float time = 0;
    public float rayDistance = 2f;
    public LayerMask layer;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        StartCoroutine(MoveChicken());
        s = GetComponent<SpriteRenderer>();                
        eventController = FindObjectOfType<DayTimeController>();        
    }

    void Update()
    {
        Vector2 rayDirection = rb.velocity.normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,rayDirection,rayDistance,layer);
        {
            if(hit.collider!=null)
            {
                vitri();
            }
        }        
        float time = eventController.Hours;        
        if (eventController != null)
        {
            //tg = eventController.Hours;
            if (time >= 18f|| time <=8f)
            {
                gotosleep();
            }
            else
            {                
                wakeup();
            }
        }
        if (sleeping == false)
        {
            rb.velocity = movement * moveSpeed;
            ani.SetFloat("Speed", rb.velocity.magnitude);          
            if (movement.x < 0)
            {
                s.flipX = true;
            }
            else if (movement.x > 0)
            {
                s.flipX = false;
            }
        }
        else                            
        {
            rb.velocity = Vector2.zero;          
        }
    }

    IEnumerator MoveChicken()
    {
        while (true)
        {
            if (l||sleeping == true)
            {                
                collider.enabled = false;
                yield return null;
            }
            else
            {
                collider.enabled = true;
                if (kv() != null)
                {
                    targetPosition = kv();
                }
                 Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;            
                movement = direction;
                bool isWalking = Random.Range(0, 2) == 1;
                if (isWalking)
                {
                    ani.SetBool("an", true);
                    ani.SetBool("dichuyen", false);                   
                    moveSpeed = 2f;  // Set walking speed
                }
                else 
                {
                    ani.SetBool("dichuyen", true);
                    ani.SetBool("an", false);                   
                    moveSpeed = 0f;   // Idle, no movement
                }                     
                float waitTime = Random.Range(1f, 3f);
                yield return new WaitForSeconds(waitTime);
            }
        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "chicken" && chicken)
        {
            StartCoroutine(Love());
            if (l)
            {
                collision.tag = tag;
            }          
        }
    }
    private Vector2 kv()
    {
        float a = Random.Range(khuvuc.x+areaSize, khuvuc.x-areaSize);
        float b = Random.Range(khuvuc.y+areaSize,khuvuc.y-areaSize);
        return new Vector2(a, b);
    }
    IEnumerator Love()
    {
        l = true;
            GameObject g = Instantiate(love, vt.position, Quaternion.identity);
            moveSpeed = 0;       
        ani.SetBool("love", true);
        Destroy(g, 3f);
        yield return new WaitForSeconds(3f);        
        if (Object)
        {          
            ani.SetBool("sinhsan", true);            
            //StartCoroutine(cd());
            yield return new WaitForSeconds(3f);
            GameObject Egg = Instantiate(egg, transform.position, Quaternion.identity);
            ani.SetBool("sinhsan", false);   
            ani.SetBool("love", false);   
        }
        else { ani.SetBool("love", false); }
        l = false;
    } 
    private void gotosleep()
    {
        sleeping = true;
        ani.SetBool("sleep", true);
    }
    private void wakeup()
    {        
        ani.SetBool("dichuyen", true);
        ani.SetBool("sleep", false);
        sleeping = false;
    }  
    private void vitri()
    {
        Vector2 newDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        movement = newDirection;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * rayDistance);
    }
}

