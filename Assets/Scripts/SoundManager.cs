using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    public void SetMusicEnabled(bool value)
    {
        music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
