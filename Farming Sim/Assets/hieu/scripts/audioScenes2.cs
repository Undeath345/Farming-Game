using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioScenes2 : MonoBehaviour
{
    [SerializeField] private Slider volum;
    [SerializeField] private Slider nen;
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioSource sound;

    private void Start()
    {
        if (audiomanager.istantace != null)
        {
            sound.volume = audiomanager.istantace.soundvolume;
           // background.volume = audiomanager.istantace.backgroundvolume; ;
        }

        if (volum != null)
        {
            volum.value = sound.volume;
            volum.onValueChanged.AddListener(ChangeVolum);
        }
        if (nen != null)
        {
            nen.value = background.volume;
            nen.onValueChanged.AddListener(SoundTrack);
        }
    }

    public void ChangeVolum(float sound1)
    {
        sound.volume = sound1;
        if (audiomanager.istantace != null)
        {
            audiomanager.istantace.SetSoundVolume(sound1);
        }
    }

    public void SoundTrack(float at)
    {
        background.volume = at;
        if (audiomanager.istantace != null) 
        {
           // audiomanager.istantace.SetBackgroundVolume(at);
        }
    }
}
