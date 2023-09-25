using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void Update()
    {
        if (GameManager.Instance.IsGameOver())
            text.text = "Score: " + GameManager.Instance.GetScore();
    }
}
