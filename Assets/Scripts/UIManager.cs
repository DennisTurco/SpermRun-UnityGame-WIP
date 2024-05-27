using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject coinText;

    private void Awake()
    {
        Instance = this;
    }

    //Show and hide UI panels
    public void ToggleDeathPanel()
    {
        Time.timeScale = 0f;
        deathPanel.SetActive(!deathPanel.activeSelf);
        SetGamePanelsOff();
    }

    public void SetGamePanelsOn()
    {
        scoreText.SetActive(true);
        coinText.SetActive(true);
    }
    public void SetGamePanelsOff()
    {
        scoreText.SetActive(false);
        coinText.SetActive(false);
    }
}