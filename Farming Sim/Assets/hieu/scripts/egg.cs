using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class egg : MonoBehaviour
{
    private Animator an;
    public GameObject chicken;  
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        StartCoroutine(cd());
    }   
    IEnumerator cd()
    {
        yield return new WaitForSeconds(5f);
        GameObject g = Instantiate(chicken, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
