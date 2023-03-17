using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEndlessRunner : MonoBehaviour
{
    public static GameManagerEndlessRunner instance = null;
    public GameObject player;
    public GameObject cameraGO;
    public bool isRunning = false;
    public float timeSinceStart;
    public GameObject canvasToShow;
    public bool canvasWasShown = false;
    public bool winCanvasShown = false;

    public int tileSpawnPercentage = 1;
    public int scoreThreshold = 50;

    public int maxCoins = 5;
    public int currentCoins = 0;
    public int tempCoins = 0;
    public int coinThreshold = 50;
    public bool canSpawnCoin = true;
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
        CheckWinCondition();
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
        if (currentCoins >= maxCoins)
        {
            allCoinsCollected = true;
        }

        switch (currentCoins)
        {
            case 0:
                coinThreshold = 25;
                break;
            case 1:
                coinThreshold = 50;
                break;
            case 2:
                coinThreshold = 75;
                break;
            case 3:
                coinThreshold = 100;
                break;
            case 4:
                coinThreshold = 125;
                break;
            case 5:
                coinThreshold = 150;
                break;
            default:
                coinThreshold = 25;
                break;

        }

        
    }

    public void ChangeCurrentScene(int sceneIndex)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Test geschafft");
        if (winCanvasShown)
        {
            Debug.Log("WinCanvas wurde erreicht");
            sceneIndex = currentSceneIndex;
        }
        
            SceneManager.LoadScene(sceneIndex);
    }

    public void CheckWinCondition()
    {
        if (currentCoins >= maxCoins)
        {
            allCoinsCollected = true;
        }
        else return;

        Debug.Log("WinCon " + allCoinsCollected);
        if (allCoinsCollected && !winCanvasShown)
        {
            Debug.Log("WinCondition erreicht");
            winCanvasShown = true;
            StartCoroutine(ShowWinCanvas());
        }
    }

    IEnumerator ShowWinCanvas()
    {
        GameObject.Find("CoinCounter").GetComponent<CoinManager>().winCanvas.SetActive(true);
        yield return new WaitForSeconds(1.5f); 
        GameObject.Find("CoinCounter").GetComponent<CoinManager>().winCanvas.SetActive(false);

    }
}
