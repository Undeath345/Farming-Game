using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu2 : MonoBehaviour
{
    [SerializeField] private GameObject pn;
    public void hpn()
    {
        pn.SetActive(true);
    }
    public void yes()
    {
        SceneManager.LoadScene(1);
    }
    public void no()
    {
        pn.SetActive(false);
    }
}
