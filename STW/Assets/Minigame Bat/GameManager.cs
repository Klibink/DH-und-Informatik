using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject storyButton;
    private GameObject obstacle;
    public GameObject endButton;
    public GameObject restartButton;
    public Player player;
    public Text gameOverCountdown;
    public float countTimer = 1;
    private AudioSource[] audio;
    public bool gameOn = false;
    public Animator animObstacle;
    public Animator animBackground;
    public Animator animPlatform;
    private DialogueTrigger[] dialogue;



    void Awake()
    {
        animObstacle = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Animator>();
        animBackground = GameObject.FindGameObjectWithTag("Background").GetComponent<Animator>();
        animPlatform = GameObject.FindGameObjectWithTag("Platform").GetComponent<Animator>();
        animObstacle.enabled = false;
        animBackground.enabled = false;
        animPlatform.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 1;
        endButton.SetActive(false);
        restartButton.SetActive(false);
        startButton.SetActive(true);
        gameOverCountdown.gameObject.SetActive(false);
        // Game Freeze = 0, Spielmodus = 1
        
        startMusic();

        dialogue = GetComponents<DialogueTrigger>();

    }
   
    private void Update()
    {
        if (player.hasWon)
        {         
            stopAnimation();
            enabled = false;
            audio[1].Stop();
            audio[0].Play();

            //triggers the winner dialogue
            dialogue[0].TriggerDialogue();

            endButton.SetActive(true);
            //restartButton.SetActive(true);
            //SceneManager.LoadScene(1);

        }

        if (player.isDead)
        {
            Debug.Log("Player is dead.");
            stopAnimation();
            enabled = false;
            audio[1].Stop();
            audio[2].Play();

            //trigger the Looser dialogue
            dialogue[1].TriggerDialogue();

            endButton.SetActive(true);
            restartButton.SetActive(true);

            //gameOverCountdown.gameObject.SetActive(true);
            //countTimer -= Time.unscaledDeltaTime;

        }

        gameOverCountdown.text = "Restarting in " + (countTimer).ToString("0");
        

        if (countTimer < 0)
        {
            RestartGame();
            Debug.Log("Restarting Game");
        }
    }

    private void animationStarter()
    {
        animObstacle.enabled = true;
        animBackground.enabled = true;
        animPlatform.enabled = true;
    }



    private void stopAnimation()
    {
        //animation in the background freezes
        animObstacle.enabled = false;
        animBackground.enabled = false;
        animPlatform.enabled = false;
    }

    public void startMusic()
    {
        audio = GetComponents<AudioSource>();
        if (audio == null)
        {
            Debug.LogError("Sound not found");
        }
        audio[1].Play();
    }

    public void toggleMusic()
    {
        //audio = GetComponents<AudioSource>();
        if (audio[1].isPlaying)
        {
            Debug.Log("Sound is playing");
            audio[1].Stop();
        } else
        {
            audio[1].Play();
        }
    }


    public void StartGame()
    {
        animationStarter();
        player.gravity = true;
        startButton.SetActive(false);
        storyButton.SetActive(false);
        gameOn = true;
        Debug.Log("Game is On");
        //Time.timeScale = 1;
        
    }

    public void GameOver()
    {
        //Throws Exception when trying to execute gameover in player script
        //Time.timeScale = 0;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        // decides if the game will progress or if the player returns to the previous state of game progress
        if (player.hasWon == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
