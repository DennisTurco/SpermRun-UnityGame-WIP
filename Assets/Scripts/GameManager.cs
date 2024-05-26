using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // references
    [SerializeField] private TextMeshPro scoreText;

    // states
    [Header("States")]
    public bool GameisOver;
    public bool GameisFinished;

    // data
    [Header("Data")]
    public float scroolSpeed;
    public int score;
    public int highScore;
    public int coins;

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
        highScore = PlayerPrefs.GetInt("highScore");
    }

    // Save state
    public void SaveState() { }
    public void LoadState(LoadSceneMode mode) { }


    //Gameover panel
    private void GameOver()
    {
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
        }

        GameisOver = true;

        // update high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
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
    public int GetScore() { return score; }
    public int GetHighScore() { return highScore; }
}
