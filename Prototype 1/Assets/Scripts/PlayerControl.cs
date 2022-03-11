using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalIn, verticalIn, momentum = 0.0f;
    private float vehicleMaxSpeed = 30.0f;
    private float vehicleAccel = 10.0f;
    private float vehicleTurnSpeed = 45.0f;
    private float slowdown = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalIn = Input.GetAxis("Horizontal");
        verticalIn = Input.GetAxis("Vertical");
        momentum += Time.deltaTime * verticalIn * vehicleAccel;

        if (verticalIn > -0.1f && momentum < 0)
        {
            momentum += slowdown * Time.deltaTime;
            if (momentum > 0) momentum = 0;
        }
        else if (verticalIn < 0.1f && momentum > 0)
        {
            momentum -= slowdown * Time.deltaTime;
            if (momentum < 0) momentum = 0;
        }
        if (momentum > vehicleMaxSpeed) momentum = vehicleMaxSpeed;
        if (momentum < vehicleMaxSpeed * -1) momentum = vehicleMaxSpeed * -1;
        if (momentum < 0.1f && momentum > -0.1f) horizontalIn = 0;
        if (momentum < 0) horizontalIn *= -1;

        transform.Translate(Vector3.forward * Time.deltaTime * momentum);
        transform.Rotate(Vector3.up, Time.deltaTime * vehicleTurnSpeed * horizontalIn);
    }
}
