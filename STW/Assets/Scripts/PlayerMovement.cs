using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float move;

    public float jump;

    private Rigidbody2D rb;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      move = Input.GetAxis("Horizontal");

      rb.velocity = new Vector2(speed * move, rb.velocity.y);

      if(Input.GetButtonDown("Jump") && !isJumping)
        {
          rb.AddForce(new Vector2(rb.velocity.x, jump));
          isJumping = true;
        }
    }

    void OnCollissionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("Ground"))
      {
        isJumping = false;
      }
    }
}
