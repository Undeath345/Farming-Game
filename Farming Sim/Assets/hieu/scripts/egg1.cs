using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class egg1 : MonoBehaviour
{
    public GameObject chicken;
    public void Start()
    {
        StartCoroutine(cd());
    }
    IEnumerator cd()
    {
        yield return new WaitForSeconds(1);
        GameObject b = Instantiate(chicken,transform.position,Quaternion.identity);
    }
}
