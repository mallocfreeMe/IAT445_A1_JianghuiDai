using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunt : MonoBehaviour
{
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fox"))
        {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
            Destroy(other.gameObject, 1);
        }
    }
}