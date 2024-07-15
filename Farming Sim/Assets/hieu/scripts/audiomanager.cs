using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager istantace;
    public float soundvolume = 1f;
  //  public float backgroundvolume = 1f;
    private void Awake()
    {
        if (istantace == null)
        {
            istantace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetSoundVolume(float volume)
    {
      soundvolume= volume;
    }

   /* public void SetBackgroundVolume(float volume)
    {
        backgroundvolume = volume;
    }*/
    public void ApplyVolumes(AudioSource sound)
    {
        sound.volume = soundvolume;
      //  background.volume = backgroundvolume;
    }
}
