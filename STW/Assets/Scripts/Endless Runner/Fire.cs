using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject player;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().isRunning)
        {
            if (player.GetComponent<PlayerMotor>().isSlowed)
            {
                speed = player.GetComponent<PlayerMotor>().GetSpeed() + 2;
            }
            else
            {
                speed = player.GetComponent<PlayerMotor>().GetSpeed() - 1;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Debug.Log("Das Feuer hat eine Geschwindigkeit von " + speed);
        }
            
    }
}
