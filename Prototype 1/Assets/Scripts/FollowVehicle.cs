using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVehicle : MonoBehaviour
{
    public GameObject player;
    private Vector3 camOffset = new Vector3(0, 8, -12);
    public Vector3 camRotationOffset = new Vector3(20, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.TransformPoint(camOffset);
        transform.rotation = player.transform.rotation;
        transform.Rotate(camRotationOffset);
    }
}
