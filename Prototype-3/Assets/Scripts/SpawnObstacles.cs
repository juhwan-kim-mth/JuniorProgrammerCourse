using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private readonly Vector3 _spawnPos = new Vector3(30, 0, 0);

    private readonly float _startDelay = 2;

    private readonly float _spawnInterval = 2;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}