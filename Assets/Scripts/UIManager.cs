using System.Drawing;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject coinsObject;
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsText.text = "x 0";
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
    }
    public void SetGamePanelsOff()
    {
        scoreText.SetActive(false);
        coinsObject.SetActive(false);
    }

    public void UpdateCoinsCounterText(int coins)
    {
        coinsText.text = "x " + coins;
        Debug.Log($"Coins: {coins}");
    }
}