using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    public float speed;
    private float lowerBound = -10, rigthBound = 25, leftBound = -25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z < lowerBound || transform.position.x < leftBound || transform.position.x > rigthBound)
        {
            Debug.Log("You lost!");
            Destroy(gameObject);
        }
    }
}
