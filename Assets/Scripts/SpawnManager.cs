using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacles;
    public float spawnRate;
    private Vector3 spawnPos = new Vector3(22, 0, 0);
    void Start()
    {
        InvokeRepeating("ObstacleSpawn", 2f , spawnRate);
    }

    public void ObstacleSpawn()
    {
        if (PlayerController.gameOver == false)
        {
            Instantiate(obstacles, spawnPos , obstacles.transform.rotation);
        }
    }
    
}
