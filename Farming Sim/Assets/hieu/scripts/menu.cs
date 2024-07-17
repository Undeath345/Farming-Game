using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class menu : MonoBehaviour
{   
    [SerializeField] private GameObject pn;
    public Slider amthanh;
    public AudioSource sound;
    private bool k;
    private void Start()
    {
        if (Audiomanager.instance != null)
        {
            Audiomanager.instance.Applyvolume(sound);
        }
        if (amthanh != null)
        {
            amthanh.value = sound.volume;
            amthanh.onValueChanged.AddListener(ChangeVolume);
            //amthanh.value = Audiomanager.instance.soundvolume;
        }
    }

    private void ChangeVolume(float sound1)
    {
       sound.volume = sound1;
        if (Audiomanager.instance != null)
        {
            Audiomanager.instance.Setsoundvolume(sound1);
        }
    }

    private void OnEnable()
    {

    }
    public void hpn()
    {
        pn.SetActive(true);
        
    }
    public void apn()
    {
        pn.SetActive(false);
        
    }
    public void play()
    {
        SceneManager.LoadScene(2);
    }
    public void dangxuat()
    {
        SceneManager.LoadScene(0);
    }
}
