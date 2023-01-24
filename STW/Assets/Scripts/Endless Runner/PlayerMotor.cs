using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 15.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 2.0f;
    private float startTime;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.z = speed;
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);

        Debug.Log(speed + " "+ isDead);
    }

    public void SetSpeed(float modifier)
    {
        speed = 10.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            Debug.Log("hab getroffen");
            if (hit.point.z > transform.position.z + controller.radius)
            {
                Death();
            }
        }
        
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
        Debug.Log("Dead");
    }
}