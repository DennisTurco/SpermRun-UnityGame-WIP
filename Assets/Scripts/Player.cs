﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 10;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private ParticleSystem particlesOnDeath;
    [SerializeField] private PowerupFlickerEffect powerupEffect;
    [SerializeField] private DamageFlickerEffect damageEffect;
    private bool powerup;
    private bool confusion;

    private void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        powerup = false;
        confusion = false;
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
        if (powerup || damageEffect.IsFlashing())
        {
            return;
        }

        if (GameManager.Instance.GetLifeCount() > 0)
        {
            GameManager.Instance.UpdateLifes(-1);
            damageEffect.StartFlicker();
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
        if (confusion)
            return;

        confusion = true;
        GameManager.Instance.SetConfusionOn();
        Invoke(nameof(SetPlayerConfusionOff), 10f);  // invoke the method after 10 seconds
    }
    public void SetPlayerConfusionOff()
    {
        confusion = false;
        GameManager.Instance.SetConfusionOff();
    }
    public void SetPlayerPowerupOn()
    {
        powerup = true;
        powerupEffect.StartFlicker();
        Invoke(nameof(SetPlayerPowerupOff), powerupEffect.GetTotalDuration());  // invoke the method after 5 seconds
    }
    public void SetPlayerPowerupOff()
    {
        powerup = false;
    }

    public bool IsPowerupEnabled()
    {
        return powerup;
    }
}