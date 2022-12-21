using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private float _spawnInterval = 10.0f;
    [SerializeField] private float _spawnRange = 6.0f;

    // Start is called before the first frame update
    private void Start()
    {
        StartSpawnEnemy();
    }

    // Update is called once per frame
    private void Update()
    {
        // 임시로 스페이스바를 눌렀을 때 Enemy생성을 멈추도록 하였다
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopSpawnEnemy();
        }
    }

    private void StartSpawnEnemy()
    {
        StartCoroutine(nameof(SpawnEnemyWaves));
    }

    private void StopSpawnEnemy()
    {
        StopCoroutine(nameof(SpawnEnemyWaves));
    }

    IEnumerator SpawnEnemyWaves()
    {
        int wavecount = 0;
        while (true)
        {
            wavecount += 1;
            for (var i = 0; i < wavecount; i++)
            {
                SpawnEnemies();
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemies()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        var randomPosX = Random.Range(-_spawnRange, _spawnRange);
        var randomPosZ = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(randomPosX, 0.1f, randomPosZ);
    }
}