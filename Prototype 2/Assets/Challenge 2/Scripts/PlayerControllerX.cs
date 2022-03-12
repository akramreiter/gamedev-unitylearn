using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private static bool canThrowDog = true;
    private float dogCooldown = 1f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canThrowDog)
        {
            canThrowDog = false;
            StartCoroutine(Cooldown());
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(dogCooldown);
        canThrowDog = true;
    }
}
