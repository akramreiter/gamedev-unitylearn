using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float powerUpStrength = 25.0f;
    public int powerUpSeconds = 7;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup;
    public bool hasPowerupStomp;
    public bool inStomp;
    public int stompJumpForce = 10;
    public int stompRange = 5;
    public int stompStrength = 25;
    public GameObject powerupIndicator;
    public GameObject powerupIndicatorStomp;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("CameraFocalPoint");
        powerupIndicator.gameObject.SetActive(false);
        powerupIndicatorStomp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float forwardIn = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardIn);
        powerupIndicator.transform.position = transform.position;
        powerupIndicatorStomp.transform.position = transform.position + new Vector3(0, -0.15f, 0);
        if (Input.GetKeyDown(KeyCode.Space) && hasPowerupStomp)
        {
            powerupIndicatorStomp.gameObject.SetActive(false);
            playerRb.AddForce(Vector3.up * stompJumpForce, ForceMode.Impulse);
            hasPowerupStomp = false;
        }
        if (transform.position.y > 2)
        {
            inStomp = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && !hasPowerup)
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
        if (other.CompareTag("PowerupStomp") && !hasPowerupStomp)
        {
            hasPowerupStomp = true;
            Destroy(other.gameObject);
            powerupIndicatorStomp.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inStomp)
        {
            inStomp = false;
            Vector3 directionEnemy;
            float distance;
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);
                if (distance < stompRange)
                {
                    directionEnemy = (enemy.gameObject.transform.position - transform.position);
                    directionEnemy.y = 0;
                    Debug.Log(directionEnemy);
                    enemy.GetComponent<Rigidbody>().AddForce(directionEnemy.normalized * stompStrength * (1/distance), ForceMode.Impulse);
                }
            }
        }
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 directionOff = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(directionOff * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpSeconds);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        Debug.Log("hasPowerup set to false");
    }
} 
