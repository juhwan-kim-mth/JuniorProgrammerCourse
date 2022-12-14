using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private PlayerController _playerControllerScript;
    private readonly float _leftBound = -15;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_playerControllerScript.gameOver == false)
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}