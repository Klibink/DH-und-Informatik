using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEndlessRunner : MonoBehaviour
{
    public static GameManagerEndlessRunner instance = null;
    public GameObject player;
    public GameObject cameraGO;
    public bool isRunning = false;
    public float timeSinceStart;
    public GameObject canvasToShow;
    public bool canvasWasShown = false;

    public int tileSpawnPercentage = 1;
    public int scoreThreshold = 50;

    public int maxCoins = 5;
    public int currentCoins = 0;
    public int coinThreshold = 100;
    public bool allCoinsCollected = false;

    // Start is called before the first frame update

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

    void Start()
    {
        CheckCoinStatus();
        //Time.timeScale = 0f;
        canvasToShow = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {

        canvasToShow = GameObject.Find("Start");
        CheckCanvasLoaded();
    }

    public void StartGame()
    {
        isRunning = true;
        canvasWasShown = true;
    }

    public void ChangeActiveState(GameObject objectToChange)
    {
        bool isActive = objectToChange.activeInHierarchy;
        objectToChange.SetActive(!isActive);
        timeSinceStart = Time.timeSinceLevelLoad;
    }

    public void CheckCanvasLoaded()
    {
        if (canvasWasShown && canvasToShow!=null)
        {
            canvasToShow.SetActive(false);
        }
    }

    public void CheckCoinStatus()
    {
        switch (currentCoins)
        {
            case 0:
                coinThreshold = 100;
                break;
            case 1:
                coinThreshold = 200;
                break;
            case 2:
                coinThreshold = 300;
                break;
            case 3:
                coinThreshold = 400;
                break;
            case 4:
                coinThreshold = 500;
                break;
            case 5:
                coinThreshold = 600;
                break;
            default:
                coinThreshold = 100;
                break;

        }

        if(currentCoins >= maxCoins)
        {
            allCoinsCollected = true;
        }
    }
}
