using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class egg1 : MonoBehaviour
{
    public GameObject[] newObject;
    public float tg;
    private Animator an;
    public bool obj = true;
    int random;
    public GameObject icon;
    public void Start()
    {        
        StartCoroutine(cd());
        an = GetComponent<Animator>();        
    } 
    IEnumerator cd()
    {
        if (obj==false)
        {
            yield return new WaitForSeconds(20);
            an.SetBool("egg", true);
            yield return new WaitForSeconds(tg);
            an.SetBool("eggc", true);
            yield return new WaitForSeconds(0.6f);
            random = Random.Range(0, 2);                                  
        }
        if (obj)
        {
            yield return new WaitForSeconds(60);
        }        
        GameObject b = Instantiate(newObject[random],transform.position,Quaternion.identity);
        if (obj)
        {
            GameObject hicon = Instantiate(icon, b.transform.position, Quaternion.identity);
            hicon.transform.SetParent(b.transform);
            hicon.transform.localPosition = new Vector2(0, 1);
        }
        if (obj==false)
        {
            Destroy(gameObject);
        }
    }   
}
