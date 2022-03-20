using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerupPrefabs;
    public float spawnRange;
    public float ballHeight = 12.5f;
    public float powerupHeight = 0.25f;
    public int waveSizeBase = 1;
    public int powerupSizeBase = 1;
    public float waveSizeGrowth = 1;
    public float powerupSizeGrowth = 0.25f;
    public int enemyCount;
    private int waveCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount < 1)
        {
            SpawnEnemyWave(waveSizeBase + (int)(waveSizeGrowth * waveCount));
            SpawnPowerupWave(powerupSizeBase + (int)(powerupSizeGrowth * waveCount));
            waveCount += 1;
        }
    }

    private Vector3 GenerateSpawnPosBall()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, ballHeight, spawnZ);
    }

    private Vector3 GenerateSpawnPosPowerup()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, powerupHeight, spawnZ);
    }

    private void SpawnEnemyWave(int waveSize)
    {
        for (int i = 0; i < waveSize; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosBall(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerupWave(int waveSize)
    {
        for (int i = 0; i < waveSize; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Powerup").Length + GameObject.FindGameObjectsWithTag("PowerupStomp").Length > 2) return;
            Instantiate(powerupPrefabs[Random.Range(0, powerupPrefabs.Length)], GenerateSpawnPosPowerup(), enemyPrefab.transform.rotation);
        }
    }
}
