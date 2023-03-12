using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D rb;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    public Animator animator;
    private SpriteRenderer sprite;
    float dirX;

    

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        

    }

    // Update is called once per frame
    private void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(dirX));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        //flip the player if walking right or left
        if (dirX > 0f)
        {
            sprite.flipX = false;
        }
        if (dirX < 0f)
        {
            sprite.flipX = true;
        }

       

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}