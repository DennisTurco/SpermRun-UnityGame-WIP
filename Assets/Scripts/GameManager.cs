using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // references
    [SerializeField] private Canvas confusionStains;

    // states
    [Header("States")]
    public bool GameisOver;
    public bool GameisFinished;

    // data
    [Header("Data")]
    public float scroolSpeed;
    public int score;
    public int highScore;
    public int totalCoins;
    public int currentCoins;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        GameisOver = false;
        GameisFinished = false;

        score = 0;
        currentCoins = 0;
        highScore = PlayerPrefs.GetInt("highScore");

        UIManager.Instance.SetGamePanelsOn();
    }

    // Save state
    public void SaveState() { }
    public void LoadState(LoadSceneMode mode) { }


    //Gameover panel
    private void GameOver()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ToggleDeathPanel();
        }

        GameisOver = true;
        SetConfusionOff();

        PlayerPrefs.SetInt("TotalCoins", currentCoins + totalCoins);

        // update high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }

        PlayerPrefs.Save();
    }

    public void SetConfusionOn()
    {
        confusionStains.gameObject.SetActive(true);
    }

    public void SetConfusionOff()
    {
        confusionStains.gameObject.SetActive(false);
    }

    // GETTER & SETTER
    public bool IsGameOver() { return GameisOver; }
    public bool IsGameFinished() { return GameisFinished; }
    public float GetScroolSpeed() { return scroolSpeed; }
    public void SetScroolSpeed(float scroolSpeed) { this.scroolSpeed = scroolSpeed; }
    public void SetGameOver()
    {
        GameOver();
        Debug.Log("GameOver");
    }
    public void SetGameFinished()
    {
        GameisFinished = true;
        Debug.Log("Game Finished, You won!");
    }
    public int UpdateAndGetScore(int score)
    {
        this.score += score * ((int)scroolSpeed);
        return this.score;
    }
    public int UpdateAndGetCoins(int currentCoins)
    {
        this.currentCoins += currentCoins;
        return this.currentCoins;
    }
    public int GetScore() { return score; }
    public int GetHighScore() { return highScore; }
    public int GetCoinsCollected() { return currentCoins; }
}