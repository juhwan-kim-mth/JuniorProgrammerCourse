using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 20;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * speed));
    }
}
