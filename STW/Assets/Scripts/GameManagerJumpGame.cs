using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerJumpGame : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject HelpButton;
    public static GameManagerJumpGame instance = null;
    public bool canvasWasShown = false;
    public GameObject canvasToShow;
    public int WaterCount;
    public int maxWaterCount = 14;

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
        Time.timeScale = 0;

        canvasToShow = GameObject.Find("Start");
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
        }
    }
}
