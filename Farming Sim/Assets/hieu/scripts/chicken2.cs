using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken2 : MonoBehaviour
{
    private Animator an;
    private void Start()
    {
        an = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chicken")
        {
            StartCoroutine(cd());
        }
    }
    IEnumerator cd()
    {        
        an.SetBool("chicken2", true);
        yield return new WaitForSeconds(3);
        an.SetBool("chicken2", false);
    }
}
