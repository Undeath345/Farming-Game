using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
// using System.Numerics;

public class menu : MonoBehaviour
{   
    [SerializeField] private GameObject pn;
    public Slider amthanh;
    public Slider bgramthanh;
    public List<AudioSource> sound;
    public AudioSource backvolume;
    private bool k;
    private void Start()
    {
        if (Audiomanager.instance != null)
        {
            Audiomanager.instance.Applyvolume(sound[0],backvolume);
        }
        if (amthanh != null && sound.Count>0)
        {
            amthanh.value = Audiomanager.instance.soundvolume;
            amthanh.onValueChanged.AddListener(ChangeVolume);
            //amthanh.value = Audiomanager.instance.soundvolume;
        }
        if (bgramthanh != null)
        {
            bgramthanh.value = backvolume.volume;
            bgramthanh.onValueChanged.AddListener(backgroundvolume);
        }
    }

    private void backgroundvolume(float bgr)
    {
        backvolume.volume = bgr;
        if(Audiomanager.instance != null)
        {
            Audiomanager.instance.backGroundvolume(bgr);
        }
    }

    private void ChangeVolume(float sound1)
    {
        foreach (var sounds in sound)
        {
            if (sound != null)
            {
                sounds.volume = sound1;
            }
            if (Audiomanager.instance != null)
            {
                Audiomanager.instance.Setsoundvolume(sound1);
            }
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
