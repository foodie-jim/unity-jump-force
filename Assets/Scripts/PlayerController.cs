using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; 
    private Animator playerAnim;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        this.playerAnim = GetComponent<Animator>();
        this.playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= this.gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.isOnGround && !this.gameOver) {
            this.playerRb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            this.isOnGround = false;
            this.playerAnim.SetTrigger("Jump_trig");
            this.dirtParticle.Stop();
            this.playerAudio.PlayOneShot(this.jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Ground")) {
            this.isOnGround = true;
            this.dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            this.gameOver = true;
            this.playerAnim.SetBool("Death_b", true);
            this.playerAnim.SetInteger("DeathType_int", 1);
            this.explosionParticle.Play();
            Debug.Log("Game Over!");
            this.playerAudio.PlayOneShot(this.crashSound, 1.0f);
            this.dirtParticle.Stop();
        }
    }
}
