using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Steuert den Spielcharakter
public class PlayerMotor : MonoBehaviour
{
    private Transform startTransform;
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 10.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 2.0f;
    private float startTime;

    public bool isInvincible = true;
    private bool isDead = false;
    public bool isSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        startTransform = this.transform;
        controller = GetComponent<CharacterController>();
        startTime = Time.timeSinceLevelLoad;
        startTransform.position = new Vector3(0f,1.0f);
        Debug.Log("Game started");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().isRunning)
        {
            //transform.position = startTransform.position;
            Debug.Log("Meine Position ist: " + transform.position);
            if (isDead)
            {
                Debug.Log("bin tot");
                return;
            }


            if (Time.timeSinceLevelLoad < GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().timeSinceStart + animationDuration)
            {
                Debug.Log("Test");
                //transform.position = new Vector3(0f,1.8f);
                transform.Translate(Vector3.forward * Time.deltaTime * 10);
                //controller.Move(startTransform.position * speed * Time.deltaTime);
                return;
            }
            isInvincible = false;
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

            Debug.Log(speed + " " + isDead);
        }
        
    }
    //Verändert die Geschwindigkeits Variabel
    public void SetSpeed(float modifier)
    {
        speed = 10.0f + modifier;
    }

    public float GetSpeed()
    {
        return speed;
    }

    //Überprüft Kollision des Spielcharakters mit anderen Objekten
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle" && !isInvincible)
        {
            Debug.Log("hab getroffen");
            
                Death();
            
        }
        else if(hit.transform.tag =="SlowObstacle" && !isInvincible)
        {
            Slowed();
            Destroy(hit.transform.gameObject);
        }
        else if(hit.transform.tag == "Coin" && !isInvincible)
        {
            Debug.Log("Gold Coin eingesammelt");
            GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().currentCoins++;
            Destroy(hit.transform.gameObject);
        }
        
    }
    //Wird aufgerufen, wenn der Spielcharakter im Spiel gestorben ist
    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
        Debug.Log("Dead");
    }
    //Verlangsamt den Spielcharakter
    private void Slowed()
    {
        StartCoroutine(SlowDown());
    }

    IEnumerator SlowDown()
    {
        isSlowed = true;
        float currentSpeed = speed;
        speed = 10.0f;
        yield return new WaitForSeconds(3f);
        speed = currentSpeed;
        isSlowed = false;

    }
}