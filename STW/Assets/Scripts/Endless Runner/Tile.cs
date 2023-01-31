using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] obstacles;

    private int maxObstacles = 5;
    private int currentObstacles = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
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
}
