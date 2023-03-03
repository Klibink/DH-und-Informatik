using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;
  public Button pauseMenuButton;
  public AudioSource audioSource;

  private bool soundOn = true;

  void Start()
  {
    GameObject.Find("PauseMenuButton").GetComponent<Button>();
    // Hinzufügen des Event-Listeners für den Button-Klick
    pauseMenuButton.onClick.AddListener(Pause);
  }

  // Update is called once per frame
  void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
    {
        if(GameIsPaused)
        {
        Resume();
        } else
      {
        Pause();
      }
    }
    }

  public void Resume ()
  {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
  }

  void Pause()
  {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
  }
  public void ToggleSound()
  {

    soundOn = !soundOn;
    audioSource.mute = !soundOn;

  }

  public void BackToMainMenu()
  {
    SceneManager.LoadScene(0);
  }
  public void QuitGame()
  {
    PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    Debug.Log("Quitting Game...");
   // SceneManager.LoadScene(0);
    Application.Quit();
  }

  

}
