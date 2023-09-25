using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeBeforeIncrementScore;

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.UpdateScore(0);
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
        text.text = "Score: " + GameManager.Instance.UpdateScore(score);
    }
}
