using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu2 : MonoBehaviour
{
    [SerializeField] private GameObject pn;
    [SerializeField] private Button bt;
    private bool k;
    private void Start()
    {
        pn.SetActive(false);
        bt.interactable = true; 
    }
    private void f()
    {

    }
    public void hpn()
    {
        pn.SetActive(true);
        Time.timeScale = 0f;
        bt.interactable = false;
    }
    public void apn()
    {
        pn.SetActive(false);
        Time.timeScale = 0f;
        bt.interactable = true;
    }
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
