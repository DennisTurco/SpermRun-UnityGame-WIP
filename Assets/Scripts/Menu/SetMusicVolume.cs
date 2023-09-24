﻿using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue)*20);
    }
}
