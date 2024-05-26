using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Button musicButton;

    private void Start()
    {
        if (SoundManager.Instance.GetMusicPlaying() == 1) musicButton.image.sprite = musicOn;
        else musicButton.image.sprite = musicOff;
    }

    public void ToggleMusic()
    {
        if (SoundManager.Instance.GetMusicPlaying() == 1) ToggleMusicOff();
        else ToggleMusicOn();
    }

    private void ToggleMusicOff()
    {
        musicButton.image.sprite = musicOff;
        SoundManager.Instance.MusicOff();
    }

    private void ToggleMusicOn()
    {
        musicButton.image.sprite = musicOn;
        SoundManager.Instance.MusicOn();
    }
}
