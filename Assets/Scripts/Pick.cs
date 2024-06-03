using System;
using UnityEngine;

public class Pick : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 screenBounds = new Vector2(0, -20);

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // get speed
        moveSpeed = -GameManager.Instance.GetScroolSpeed();

        // move the pick
        rb.velocity = new Vector2(0, moveSpeed);

        // auto destroy if the object exit the bounds
        if (transform.position.y < screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (this.gameObject.CompareTag("Coin"))
            {
                CollectCoin(collision);
            }
            else if (this.gameObject.CompareTag("Life"))
            {
                CollectLife(collision);
            }
            else if (this.gameObject.CompareTag("Redbull"))
            {
                CollectRedbull(collision);
            }
            else
            {
                throw new Exception("Invalid or missing tag to the object");
            }
        }
    }

    private void CollectCoin(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            SoundManager.Instance.PlayCoinSound();
            GameManager.Instance.IncrementCoins();
            Destroy(this.gameObject);
        }
    }
    private void CollectLife(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            SoundManager.Instance.PlayLifeSound();
            GameManager.Instance.UpdateLifes(1);
            Destroy(this.gameObject);
        }
    }
    private void CollectRedbull(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            SoundManager.Instance.PlayRedbullSound();
            player.SetPlayerPowerupOn();
            Destroy(this.gameObject);
        }
    }
}