using System.Collections;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        GameManager.Instance.UpdateAndGetCoins(0);
        text.text = "Coins: 0";
    }

    public void IncrementCoinsText()
    {
        var coins = GameManager.Instance.UpdateAndGetCoins(1);
        text.text = "Coins: " + coins;
        Debug.Log($"Coins: {coins}");
    }
}