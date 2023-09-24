using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // references


    // states
    [Header("States")]
    public bool GameisOver;
    public bool GameisFinished;

    // data
    [Header("Data")]
    public float scroolSpeed;
    public int score;

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
    }

    // Save state
    public void SaveState() { }
    public void LoadState(LoadSceneMode mode) { }


    //Gameover panel
    public void GameOver()
    {
        /*
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
        GameisOver = true;
        */
    }

    // GETTER & SETTER
    public bool IsGameOver() { return GameisOver; }
    public bool IsGameFinished() { return GameisFinished; }
    public float GetScroolSpeed() { return scroolSpeed; }
    public void SetScroolSpeed(float scroolSpeed) { this.scroolSpeed = scroolSpeed; }
    public void SetGameOver()
    {
        GameisOver = true;
        Debug.Log("GameOver");
    }
    public void SetGameFinished()
    {
        GameisFinished = true;
        Debug.Log("Game Finished, You won!");
    }
    public void UpdateScore(int score)
    {
        this.score += score;
    }
}
