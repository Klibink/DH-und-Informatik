using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerJumpGame : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject HelpButton;
    public GameObject endCircle;
    public static GameManagerJumpGame instance = null;
    public bool canvasWasShown = false;
    public GameObject canvasToShow;
    public int WaterCount;
    public int maxWaterCount = 14;

    public bool gameStarted = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       // Time.timeScale = 0;

        canvasToShow = GameObject.Find("Start");
        WaterCount = 0;
        if (endCircle != null)
            endCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanvasLoaded();
        canvasToShow = GameObject.Find("Start");
        checkWaterCount();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        StartButton.SetActive(false);
        HelpButton.SetActive(false);
        
        canvasWasShown = true;
        gameStarted = true; 
     
    }

    public void CheckCanvasLoaded()
    {
        if (canvasWasShown && canvasToShow != null)
        {
            canvasToShow.SetActive(false);
        }
    }

    public void checkWaterCount()
    {
        if (WaterCount == maxWaterCount)
        {
            Debug.Log("Gewonnen");
            if (endCircle != null) 
            endCircle.SetActive(true); 
        }
    }

  /*  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndsceneCircle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
  */
}
