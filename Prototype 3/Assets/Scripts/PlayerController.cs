using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody rb;
    private Animator animator;
    private int jumpsAvailable = 2;
    public bool gameOver = false;
    public ParticleSystem smokeExplosion;
    public ParticleSystem dirtLanding;
    public AudioClip jumpSfx;
    public AudioClip crashSfx;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpsAvailable > 0 && !gameOver)
        {
            playerAudio.PlayOneShot(jumpSfx, 1.0f);
            dirtLanding.Stop();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpsAvailable -= 1;
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (jumpsAvailable < 2)
            {
                dirtLanding.Play();
            }
            jumpsAvailable = 2;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSfx, 1.0f);
            dirtLanding.Stop();
            smokeExplosion.Play();
            gameOver = true;
            Debug.Log("Game Over!");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }
    }
}
