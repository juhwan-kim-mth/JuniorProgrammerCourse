using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private readonly Vector3 _spawnPos = new Vector3(30, 0, 0);

    private readonly float _startDelay = 2;

    private readonly float _spawnInterval = 2;

    private PlayerController _playerControllerScript;
    
    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void SpawnObstacle()
    {
        if (_playerControllerScript.gameOver == false)
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}