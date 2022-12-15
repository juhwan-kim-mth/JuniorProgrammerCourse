using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool onGround = true;
    private Rigidbody _playerRb;
    private Animator _playerAnimator;
    private AudioSource _playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    public bool gameOver;
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    private void Update()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        onGround = false;
        _playerAnimator.SetTrigger(JumpTrig);
        dirtParticle.Stop();
        _playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            {
                onGround = true;
                dirtParticle.Play();
                break;
            }
            case "Obstacle":
            {
                Debug.Log("Game Over");
                gameOver = true;
                _playerAnimator.SetBool(DeathB, true);
                _playerAnimator.SetInteger(DeathTypeINT, 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                _playerAudio.PlayOneShot(crashSound, 0.8f);
                break;
            }
        }
    }
}