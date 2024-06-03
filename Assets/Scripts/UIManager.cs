using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject coinsObject;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject lifesObject;
    [SerializeField] private TextMeshProUGUI lifesText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsText.text = "x 0";
        lifesText.text = "x 0";
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
        coinsObject.SetActive(true);
        lifesObject.SetActive(true);
    }
    public void SetGamePanelsOff()
    {
        scoreText.SetActive(false);
        coinsObject.SetActive(false);
        lifesObject.SetActive(false);
    }

    public void UpdateCoinsCounterText(int coins)
    {
        coinsText.text = "x " + coins;
        Debug.Log($"Coins: {coins}");
    }

    public void UpdateLifesCounterText(int lifes)
    {
        lifesText.text = "x " + lifes;
        Debug.Log($"Lifes: {lifes}");
    }
}