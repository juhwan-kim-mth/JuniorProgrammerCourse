using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _forceMagnitude = 3.0f;

    private GameObject _player;

    private Rigidbody _enemyRb;

    private Vector3 _lookDirection;

    private float _distanceEnemyPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.Find("Player");
        _enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        _lookDirection = (_player.transform.position - transform.position).normalized; 
        _enemyRb.AddForce(_lookDirection * _forceMagnitude);
    }
}