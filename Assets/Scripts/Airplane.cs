using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Transform originalPosition;
    
    private Vector3 _originalPosition;
    private AudioSource _audioSource;

    private void Start()
    {
        _originalPosition = new Vector3(originalPosition.position.x, originalPosition.position.y,originalPosition.position.z);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(3 * Time.deltaTime, 3 * Time.deltaTime, 10 * Time.deltaTime);
        if (Vector3.Distance(_originalPosition, transform.position) > 200)
        {
            transform.position = _originalPosition;
            _audioSource.Play();
        }
    }
}
