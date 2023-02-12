using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;
    public Player player;
    public Text gameOverCountdown;
    public float countTimer = 1;
    private AudioSource[] audio;


    // Start is called before the first frame update
    void Start()
    {
        startButton.SetActive(true);
        gameOverCountdown.gameObject.SetActive(false);
        // Game Freeze = 0, Spielmodus = 1
        Time.timeScale = 0;
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

    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
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