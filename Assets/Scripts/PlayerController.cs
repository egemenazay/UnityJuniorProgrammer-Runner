using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    public static bool gameOver = false;
    public float jumpForce = 10f;
    public float gravityModifier;
    private bool _isGrounded = true;
    public Animator plyrAnimator;
    public ParticleSystem deathFX;
    public ParticleSystem runFX;
    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    private AudioSource _playerAudio;
    private void Start()
    {
        _playerAudio = GetComponent<AudioSource>();
        _playerRb = GetComponent<Rigidbody>();
        plyrAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded == true) && (gameOver == false))
        {
            Jump();
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            runFX.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            runFX.Stop();
            deathFX.Play();
            _playerAudio.PlayOneShot(deathSFX,1f);
            _isGrounded = true;
            gameOver = true;
            Debug.Log("Game Over");
            plyrAnimator.SetBool("Death_b", true);
            plyrAnimator.SetInteger("DeathType_int", 1);
        }
    }

    public void Jump()
    {
        _playerAudio.PlayOneShot(jumpSFX, 1f);
        plyrAnimator.SetTrigger("Jump_trig");
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        runFX.Stop();
    }
}
