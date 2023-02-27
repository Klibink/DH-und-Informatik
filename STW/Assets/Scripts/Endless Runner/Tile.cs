using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] spawnRows;
    public GameObject[] obstacles;

    private int maxObstacles = 5;
    private int maxObstaclesInRow = 2;
    private int currentObstacles = 0;
    private int currentObstaclesInRow = 0;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnObstacle();
        SpawnObstacleInRow();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject go;

        for(int i = 0; i < spawnRows.Length; i++)
        {
            foreach (Transform child in spawnRows[i].transform)
            {
                Debug.Log(child.name);
                if (currentObstaclesInRow < maxObstaclesInRow)
                {
                    if (Random.Range(0, 5) <= 1)
                    {
                        go = Instantiate(obstacles[Random.Range(0, obstacles.Length)]) as GameObject;
                        go.transform.position = child.transform.position;
                        currentObstaclesInRow++;
                        currentObstacles++;
                        go.transform.SetParent(child.transform);
                    }
                }
            }
        }

        
    }
}
