using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private float startDelay = 2;
    private float spawnIntervalMin = 1.5f;
    private float spawnIntervalMax = 2.5f;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", startDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
            Invoke("SpawnObstacle", Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }
}
