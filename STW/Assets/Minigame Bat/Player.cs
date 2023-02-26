using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;
    public GameManager gameManager;
    public bool isDead = false;
    public bool hasWon = false;
    public bool gravity = false;
    


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity == true) 
        {
            rigidbody.gravityScale = 1;
        }
        
        if (Input.GetKey("space"))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("You Won (Player Class)");
            hasWon = true;
        } else
        {
            isDead = true;
            Debug.Log("Collision executed");
            // gameManager.GameOver();
        }
    }
}

