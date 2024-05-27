using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeBeforeIncrementScore;

    private void Start()
    {
        GameManager.Instance.UpdateAndGetScore(0);
        text.text = "Score: 0";

        StartCoroutine("IncrementScore");
    }

    private IEnumerator IncrementScore()
    {
        while (true)
        {
            UpdateScoreText(1);
            yield return new WaitForSeconds(timeBeforeIncrementScore);
        }
    }

    private void UpdateScoreText(int score)
    {
        var value = GameManager.Instance.UpdateAndGetScore(score);
        text.text = "Score: " + value;
        Debug.Log($"Score: {value}");
    }
}