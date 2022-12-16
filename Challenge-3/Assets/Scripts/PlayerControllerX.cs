using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private readonly float _gravityModifier = 1.5f;
    private Rigidbody _playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource _playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    private void Start()
    {
        Physics.gravity *= _gravityModifier;
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    private void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            _playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            // if player collides with bomb, explode and set gameOver to true
            case "Bomb":
            {
                explosionParticle.Play();
                _playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                break;
            }
            // if player collides with money, fireworks
            case "Money":
            {
                fireworksParticle.Play();
                _playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
                break;
            }
            case "Ground":
            {
                _playerRb.velocity = new Vector3(0, -0.5f * _playerRb.velocity.y, 0);
                _playerAudio.PlayOneShot(bounceSound, 1.0f);
                break;
            }
        }
    }
}