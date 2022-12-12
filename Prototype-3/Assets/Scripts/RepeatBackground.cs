using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;

    [SerializeField] private float offset;

    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < _startPos.x - offset)
        {
            transform.position = _startPos;
        }
    }
}