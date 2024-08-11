using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator ani;
    public bool moving;
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       ani = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector.x = horizontal;
        motionVector.y = vertical;

        ani.SetFloat("horizontal", horizontal);
        ani.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        ani.SetBool("moving", moving);


        if ( horizontal != 0 ||  vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
                ).normalized;
            ani.SetFloat("lastHorizontal", horizontal );
            ani.SetFloat("lastVertical", vertical );
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = motionVector * speed ;
    }
}
