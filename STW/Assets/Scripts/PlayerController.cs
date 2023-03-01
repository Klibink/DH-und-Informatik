using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

  public float moveSpeed = 1f;
  public float collisionOffset = 0.05f;
  public ContactFilter2D movementFilter;
  public void SavePlayer()
  {
    SaveSystem.SavePlayer(this);
  }

  public void LoadPlayer()
  {
    PlayerData data = SaveSystem.LoadPlayer();

    Vector3 position;
    position.x = data.position[0];
    position.y = data.position[1];
    position.z = data.position[2];
    transform.position = position;


  }

  Vector2 movementInput;

  SpriteRenderer spriteRenderer;

  Rigidbody2D rb;

  Animator animator;

  List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }


  private void FixedUpdate()
  {
    if (movementInput != Vector2.zero)
    {
      bool success = TryMove(movementInput);

      if (!success)
      {
        success = TryMove(new Vector2(movementInput.x, 0));

        if (!success)
        {
          success = TryMove(new Vector2(0, movementInput.y));
        }
      }
      animator.SetFloat("Horizontal", movementInput.x);
      animator.SetFloat("Vertical", movementInput.y);
      animator.SetFloat("Speed", movementInput.sqrMagnitude);
    }
    else
    {
      animator.SetFloat("Horizontal", movementInput.x);
      animator.SetFloat("Vertical", movementInput.y);
      animator.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    //Richtung des Sprites ändern
    if (movementInput.x < 0)
    {
      spriteRenderer.flipX = true;
    }
    else if (movementInput.x > 0)
    {
      spriteRenderer.flipX = false;
    }
  }

  private bool TryMove(Vector2 direction)
  {
    if (direction != Vector2.zero)
    {
      int count = rb.Cast(
          direction,
          movementFilter,
          castCollision,
          moveSpeed * Time.fixedDeltaTime + collisionOffset);

      if (count == 0)
      {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        return true;
      }
      else
      {
        return false;
      }
    }
    else
    {
      return false;
    }
  }

  void OnMove(InputValue movementValue)
  {
    movementInput = movementValue.Get<Vector2>();
  }
}
