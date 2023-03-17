using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dieses Skript steuert die Kamera. Zu Beginn wird eine kurze Animation abgespielt und danach folgt die Kamera dem Spielcharakter
public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationCameraOffset = new Vector3(0, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        transform.position = new Vector3(0, 8, -5);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().isRunning)
        {
            moveVector = lookAt.position + startOffset;
            moveVector.x = 0f;
            moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

            if (transition > 1.0f)
            {
                transform.position = moveVector;
            }
            else
            {
                //Animation at start of the game
                transform.position = Vector3.Lerp(moveVector + animationCameraOffset, moveVector, transition);
                transition += Time.deltaTime * 1 / animationDuration;
                transform.LookAt(lookAt.position + Vector3.up);
            }
        }
            
    }
}
