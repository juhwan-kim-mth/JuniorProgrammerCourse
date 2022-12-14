using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool onGround = true;
    private Rigidbody _playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    public bool gameOver;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        onGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            {
                onGround = true;
                break;
            }
            case "Obstacle":
            {
                Debug.Log("Game Over");
                gameOver = true;
                break;
            }
        }
    }
}