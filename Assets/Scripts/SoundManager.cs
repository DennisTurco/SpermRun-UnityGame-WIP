using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSound;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource virusSound;
    [SerializeField] private AudioSource lifeSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource redbullSound;
    private int musicPlaying;
    private int volumePlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadAudioPreferences();
    }

    private void LoadAudioPreferences()
    {
        musicPlaying = PlayerPrefs.GetInt("MusicPlaying");
        volumePlaying = PlayerPrefs.GetInt("VolumePlaying");
    }
    private void SaveVolumePreference()
    {
        PlayerPrefs.GetInt("VolumePlaying", volumePlaying);
    }
    private void SaveMusicPreference()
    {
        PlayerPrefs.GetInt("MusicPlaying", musicPlaying);
    }


    public void PlayButtonSound()
    {
        if (volumePlaying == 1)
            buttonSound.PlayOneShot(buttonSound.clip);
    }
    public void PlayCoinSound()
    {
        if (volumePlaying == 1)
            coinSound.PlayOneShot(coinSound.clip);
    }
    public void PlayVirusSound()
    {
        if (volumePlaying == 1)
            virusSound.PlayOneShot(virusSound.clip);
    }
    public void PlayLifeSound()
    {
        if (volumePlaying == 1)
            lifeSound.PlayOneShot(lifeSound.clip);
    }
    public void PlayRedbullSound()
    {
        if (volumePlaying == 1)
            redbullSound.PlayOneShot(redbullSound.clip);
    }
    public void PlayDeathSound()
    {
        if (volumePlaying == 1)
            deathSound.PlayOneShot(deathSound.clip);
    }

    public void MusicOn() 
    {
        musicSound.Play();
        musicPlaying = 1;
        SaveMusicPreference();
        Debug.Log("Music On");
    }
    public void MusicOff()
    {
        musicSound.Pause();
        musicPlaying = 0;
        SaveMusicPreference();
        Debug.Log("Music Off");
    }
    public void VolumeOn()
    {
        buttonSound.Play();
        volumePlaying = 1;
        SaveVolumePreference();
        Debug.Log("Volume On");
    }
    public void VolumeOff()
    {
        buttonSound.Pause();
        volumePlaying = 0;
        SaveVolumePreference();
        Debug.Log("Volume Off");
    }

    public int GetMusicPlaying()
    {
        return musicPlaying;
    }
    public int GetVolumePlaying()
    {
        return volumePlaying;
    }
}