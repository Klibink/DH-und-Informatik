using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] spawnRows;
    public GameObject[] obstacles;
    public GameObject coinPrefab;
    public GameObject gameManager;

    private int maxObstacles = 5;
    private int maxObstaclesInRow = 2;
    private int currentObstacles = 0;
    private int currentObstaclesInRow = 0;
    private int maxRandomNumber = 10;
    private int spawnPercentage = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        spawnPercentage = gameManager.GetComponent<GameManagerEndlessRunner>().tileSpawnPercentage;
        //SpawnObstacle();
        SpawnObstacleInRow();
    }

    // Update is called once per frame
    void Update()
    {
        float tempScore = 1;
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().GetScore() > 50)
        {
            tempScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().GetScore() % 50;
        }
        

        if (tempScore == 0) 
        {
            spawnPercentage++;
        }
    }

    private void SpawnObstacle()
    {
        GameObject go;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 5) <= 1 && currentObstacles <= maxObstacles)
            {
                go = Instantiate(obstacles[Random.Range(0, obstacles.Length)]) as GameObject;
                go.transform.position = spawnPoints[i].transform.position;
                go.transform.rotation = Quaternion.Euler(Random.Range(0, 360), 0, 0);
                currentObstacles++;
                go.transform.SetParent(transform);
            }
        }
    }

    /*private void SpawnObstacleInRow()
    {
        GameObject go;
        for (int i = 0; i < spawnRows.Length; i++)
        {
            foreach(GameObject child in spawnRows)
            {
                Debug.Log(child.name);
                if(currentObstaclesInRow <= maxObstaclesInRow)
                {
                    if(Random.Range(0,5) <= 1)
                    {
                        go = Instantiate(obstacles[Random.Range(0, obstacles.Length)]) as GameObject;
                        go.transform.position = child.transform.position;
                        currentObstaclesInRow++;
                        currentObstacles++;
                        go.transform.SetParent(spawnRows[i].transform);
                    }
                }
            }
        }
    }*/
    private void SpawnObstacleInRow()
    {
        CheckPlayerScore();
        Debug.Log("SpawnChance: " + spawnPercentage);
        GameObject go;

        for(int i = 0; i < spawnRows.Length; i++)
        {
            foreach (Transform child in spawnRows[i].transform)
            {
                Debug.Log(child.name);
                if (currentObstaclesInRow < maxObstaclesInRow)
                {
                    if (Random.Range(0, maxRandomNumber) <= spawnPercentage)
                    {
                        go = Instantiate(obstacles[Random.Range(0, obstacles.Length)]) as GameObject;
                        go.transform.position = child.transform.position;
                        go.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                        currentObstaclesInRow++;
                        currentObstacles++;
                        go.transform.SetParent(child.transform);
                    }
                    else
                    {
                        Debug.Log("Gold Schleife erreicht");
                        if(GameObject.Find("player").GetComponent<Score>().GetScore() > GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().coinThreshold && GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().currentCoins < 5)
                        {
                            Debug.Log("Gold Coin spawned");
                            GameObject.Find("GameManager").GetComponent<GameManagerEndlessRunner>().coinThreshold += 100;
                            go = Instantiate(coinPrefab) as GameObject;
                            go.transform.position = child.transform.position;
                            go.transform.position = new Vector3(child.transform.position.x, child.transform.position.y + 1, child.transform.position.z);
                            go.transform.SetParent(child.transform);
                        }
                    }
                }
            }
        }

        
    }

    private void CheckPlayerScore()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().GetScore() > gameManager.GetComponent<GameManagerEndlessRunner>().scoreThreshold && spawnPercentage < 6)
        {
            gameManager.GetComponent<GameManagerEndlessRunner>().scoreThreshold += 50;
            gameManager.GetComponent<GameManagerEndlessRunner>().tileSpawnPercentage++;
        }
    }
}
