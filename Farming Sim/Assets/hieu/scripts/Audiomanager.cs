using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;
    public float soundvolume = 1f;
    public float backgroundVolume = 1f;
    private bool j;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void backGroundvolume(float bgrVolume)
    {
        backgroundVolume = bgrVolume;
    }
    public void Setsoundvolume(float volume)
    {
        soundvolume = volume;
    }
    public void Applyvolume (AudioSource sound)
    {
        sound.volume = soundvolume;
    }
}
