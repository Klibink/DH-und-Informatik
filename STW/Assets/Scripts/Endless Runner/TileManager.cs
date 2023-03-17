using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawnt Tiles aufeinanderfolgend an der letzten gegebenen Position
public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject spawnTile;

    private Transform playerTransform;
    private float spawnZ = -10.0f;
    private float tileLength = 20f;
    private float safeZone = 50.0f;
    private int amountTilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i< amountTilesOnScreen; i++)
        {
            if (i < 3)
            {
                SpawnStartTile();
            }
            else
                SpawnTile();
        }
        if (player.GetComponent<PlayerMotor>().isInvincible)
        {
            for (int i = 0; i < activeTiles.Count; i++)
            {
                activeTiles[i].GetComponentInChildren<MeshCollider>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < activeTiles.Count; i++)
            {
                activeTiles[i].GetComponentInChildren<MeshCollider>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMotor>().isInvincible)
        {
            for(int i = 0; i < activeTiles.Count; i++)
            {
                activeTiles[i].GetComponentInChildren<MeshCollider>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < activeTiles.Count; i++)
            {
                activeTiles[i].GetComponentInChildren<MeshCollider>().enabled = true;
            }
        }

        if(playerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
        {
            SpawnTile(0);
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private void SpawnStartTile()
    {
        GameObject go;
        go = Instantiate(spawnTile) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
}
