using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pn;
    [SerializeField] private GameObject pn2;
    [SerializeField] Slider volum;
    private void Start()
    {
        if (volum != null)
        {
            volum.value = AudioListener.volume;
            volum.onValueChanged.AddListener(ChangeVolum);
        }
    }

    public void ChangeVolum(float arg0)
    {
        AudioListener.volume = arg0;
    }

    public void play()
    {
        SceneManager.LoadScene(2);
    }
    public void LogOut()
    {
        SceneManager.LoadScene(0);
    }
    public void hpn()
    {
        pn.SetActive(true);
        pn2.SetActive(false);
    }
    public void apn()
    {
        pn.SetActive(false);
        pn2.SetActive(true);
    }
}
