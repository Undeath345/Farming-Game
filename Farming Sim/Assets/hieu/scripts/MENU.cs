using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pn;
    [SerializeField] private Slider volum;
    [SerializeField] private Slider nen;
  //  [SerializeField] private AudioSource background;    
    [SerializeField] private AudioSource sound;    
    private void Start()
    {
        if (audiomanager.istantace != null)
        {
           audiomanager.istantace.ApplyVolumes(sound);
        }

        if (volum != null)
        {                       
            volum.value = sound.volume;
            volum.onValueChanged.AddListener(ChangeVolum);            
        }
     /*   if (nen != null)
        {
            nen.value = background.volume;
            nen.onValueChanged.AddListener(SoundTrack);
        }*/
    }

    public void ChangeVolum(float sound1)
    {
       sound.volume = sound1;
        if (audiomanager.istantace != null)
        {
            audiomanager.istantace.SetSoundVolume(sound1);
            audiomanager.istantace.ApplyVolumes(sound);
        }
    }
   /* public void SoundTrack(float at)
    {
        background.volume = at;
        if (audiomanager.istantace != null)
        {
            audiomanager.istantace.SetBackgroundVolume(at);
            audiomanager.istantace.ApplyVolumes(sound, background);

        }
    }*/
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
    }
    public void apn()
    {
        pn.SetActive(false);
    }   
}
