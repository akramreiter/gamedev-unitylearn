using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public GameObject[] wildLeftAnimals;
    public GameObject[] wildRightAnimals;
    private GameObject wildAnimal;
    private int animalIndex;
    private float spawnRangeX = 15, 
        spawnPosZ = 20,
        spawnWildPosLeft = 20,
        spawnWildPosRight = -20,
        spawnWildRangeZ = 5,
        spawnWildRangeZCenter = 10,
        startDelay = 2, 
        spawnInterval = 1.5f, 
        spawnWildMinInterval = 1, 
        spawnWildMaxInterval = 4,
        spawnWild;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
        Invoke("SpawnWildAnimal", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWildAnimal()
    {
        if (Random.Range(0, 2) > 0)
        {
            wildAnimal = wildLeftAnimals[Random.Range(0, wildLeftAnimals.Length)];
            spawnWild = spawnWildPosLeft;
        } 
        else
        {
            wildAnimal = wildRightAnimals[Random.Range(0, wildRightAnimals.Length)];
            spawnWild = spawnWildPosRight;
        }
        Instantiate(wildAnimal, new Vector3(spawnWild, 0, Random.Range(-spawnWildRangeZ, spawnWildRangeZ) + spawnWildRangeZCenter), wildAnimal.transform.rotation);
        Invoke("SpawnWildAnimal", Random.Range(spawnWildMinInterval, spawnWildMaxInterval));
    }

    void SpawnAnimal()
    {
        animalIndex = Random.Range(0, animals.Length);
        Instantiate(animals[animalIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ), animals[animalIndex].transform.rotation);
    }
}
