using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunt : MonoBehaviour
{
    public AudioClip audioClip;
    public ParticleSystem deathParticles;

    // if FPS collides with a fox
    // then fox should be removed, and play its death sound and instantiate death particles 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fox"))
        {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
            Instantiate(deathParticles, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject, 1);
        }
    }
}