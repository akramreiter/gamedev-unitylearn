using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnMinInterval = 3;
    private float spawnMaxInterval = 5;
    private int ballId;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        ballId = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballId], spawnPos, ballPrefabs[ballId].transform.rotation);
        Invoke("SpawnRandomBall", Random.Range(spawnMinInterval, spawnMaxInterval));
    }
}
