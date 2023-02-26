using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private Vector2 Movement;
  private Rigidbody2D rb;

  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }


  private void OnMovement(InputValue value) {
    Movement = value.Get<Vector2>();
  }

  private void FixedUpdate() {
    rb.MovePosition(rb.position + Movement * Time.fixedDeltaTime);
  }


}
