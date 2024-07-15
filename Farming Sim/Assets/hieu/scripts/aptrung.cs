using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class aptrung : MonoBehaviour
{
    [SerializeField] private GameObject vt;
    [SerializeField] float speed = 5f;
    [SerializeField] private GameObject egg;
    private Animator an;
    private GameObject f;
    private Rigidbody2D rb;
    private bool k = false;
    private void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ga")
        {
            StartCoroutine(dt());
        }        
    }
    IEnumerator dt()
    {
        yield return new WaitForSeconds(4f);
        while (Vector2.Distance(transform.position,vt.transform.position) > 0.1f)
        {
            Vector2 d = (vt.transform.position - transform.position).normalized;
            rb.velocity = d * speed;
            k=true;
            yield return null;
        }
        an.SetBool("aptrung2", true);        
        rb.velocity = Vector2.zero;  
        if (k)
        {
            GameObject b = Instantiate(egg, transform.position, Quaternion.identity);
        }
    }
}
