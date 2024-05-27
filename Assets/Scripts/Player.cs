using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 10;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private ParticleSystem particlesOnDeath;
    private bool powerup;

    private void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        powerup = false;
    }

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
        if (powerup)
        {
            return;
        }

        // play particles
        if (particlesOnDeath != null)
            particlesOnDeath.Play();

        // destroy object
        //gameObject.SetActive(false);

        SoundManager.Instance.PlayDeathSound();
        GameManager.Instance.SetGameOver();
    }

    public void SetPlayerConfusionOn()
    {
        GameManager.Instance.SetConfusionOn();
        Invoke(nameof(SetPlayerConfusionOff), 10f);  // invoke the method after 10 seconds
    }
    public void SetPlayerConfusionOff()
    {
        GameManager.Instance.SetConfusionOff();
    }
    public void SetPlayerPowerupOn()
    {
        powerup = true;
        Invoke(nameof(SetPlayerPowerupOff), 5f);  // invoke the method after 5 seconds
    }
    public void SetPlayerPowerupOff()
    {
        powerup = false;
    }
}