using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    public int pointValue;
    public bool isGood;
    public ParticleSystem explosion;
    private float maxSpeed = 15.0f, minSpeed = 12.0f, maxTorgue = 10, xRange = 4, yPos = -2;
    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
            if (isGood)
            {
                gameManager.SetGameOverState();
            }
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorgue, maxTorgue);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        if (!isGood)
        {
            gameManager.SetGameOverState();
        }
    }

    private void OnTriggerEntry(Collider other)
    {
        Destroy(gameObject);
    }
}
