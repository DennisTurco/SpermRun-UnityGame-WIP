using UnityEngine;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    [SerializeField] private Sprite volumeOn;
    [SerializeField] private Sprite volumeOff;
    [SerializeField] private Button volumeButton;

    private void Start()
    {
        if (SoundManager.Instance.GetVolumePlaying() == 1) volumeButton.image.sprite = volumeOn;
        else volumeButton.image.sprite = volumeOff;
    }

    public void ToggleVolume()
    {
        if (SoundManager.Instance.GetVolumePlaying() == 1) ToggleVolumeOff();
        else ToggleVolumeOn();
    }

    private void ToggleVolumeOff()
    {
        volumeButton.image.sprite = volumeOff;
        SoundManager.Instance.VolumeOff();
    }

    private void ToggleVolumeOn()
    {
        volumeButton.image.sprite = volumeOn;
        SoundManager.Instance.VolumeOn();
    }
}
