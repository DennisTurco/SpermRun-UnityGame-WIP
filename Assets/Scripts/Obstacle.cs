using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 screenBounds = new Vector2(0, -20);

    // Use this for initialization
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // get speed
        moveSpeed = GameManager.Instance.GetScroolSpeed();

        // move the obstacle
        rb.velocity = new Vector2(0, moveSpeed);

        // auto destroy if the object exit the bounds
        if (transform.position.y < screenBounds.y)
        {
            // update score
            GameManager.Instance.UpdateAndGetScore(10); // every obstacle passed, increment by 10 points

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.PlayerDie();
        }
    }
}
