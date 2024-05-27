using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ScoreType scoreType;

    public void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            switch (scoreType)
            {
                case ScoreType.CurrentScore:
                    text.text = "Score: " + GameManager.Instance.GetScore();
                    break;
                case ScoreType.HighScore:
                    text.text = "High Score: " + GameManager.Instance.GetHighScore();
                    break;
                case ScoreType.CoinsCollected:
                    text.text = "Coins Collected: " + GameManager.Instance.GetCoinsCollected();
                    break;
                default:
                    break;
            }
        }
            
    }
}

enum ScoreType
{
    CurrentScore,
    HighScore,
    CoinsCollected
}
