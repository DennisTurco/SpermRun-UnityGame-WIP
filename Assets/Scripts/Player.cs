using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 10;
    [SerializeField] private Rigidbody2D player;  

    // Start is called before the first frame update
    private void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float X = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(X, 0) * movespeed;    
    }

    public void PlayerDie()
    {
        gameObject.SetActive(false);
        GameManager.Instance.SetGameOver();
    }
}