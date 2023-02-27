using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject storyButton;
    public Player player;
    public Text gameOverCountdown;
    public float countTimer = 1;
    private AudioSource[] audio;
    public bool gameOn = false;
    private GameObject obstacle;
    public Animator animObstacle;
    public Animator animBackground;
    public Animator animPlatform;


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
        startButton.SetActive(true);
        gameOverCountdown.gameObject.SetActive(false);
        // Game Freeze = 0, Spielmodus = 1
        
        audio = GetComponents<AudioSource>();
        if (audio == null)
        {
            Debug.LogError("Sound not found");
        }
        audio[1].Play();



    }
   
    private void Update()
    {
        if (player.hasWon)
        {
            
            Time.timeScale = 0;
            enabled = false;
            audio[1].Stop();
            audio[0].Play();
            
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        if (player.isDead)
        {
            
            Debug.Log("Player is dead.");
            Time.timeScale = 0;

            gameOverCountdown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
            
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
        SceneManager.LoadScene(3);
    }
}