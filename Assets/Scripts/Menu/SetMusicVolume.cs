using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public float volume;

    private void Start()
    {
        //LoadVolume();
    }

    public void SetLevel(float sliderValue)
    {
        volume = sliderValue;
        mixer.SetFloat("MusicVol", Mathf.Log10 (volume)*20);

        SaveVolume();
        LoadVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVol", volume);
        PlayerPrefs.Save();
    }

    //TODO: fixhere 
    private void LoadVolume()
    {
        volume = PlayerPrefs.GetFloat("MusicVol");
        mixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }
}
