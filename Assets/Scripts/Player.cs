using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movespeed = 10;
    public Rigidbody2D player;
   

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        float Y = Input.GetAxis("Vertical");
        float X = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(X, 0) * movespeed;    
    }
}