﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    // if airplane exit the invisible collider
    // then transfer the player to the corresponding scene 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Airplane"))
        {
            if (SceneManager.GetActiveScene().name == "Island One")
            {
                SceneManager.LoadScene("Island Two");
            }
            else
            {
                SceneManager.LoadScene("Island One");
            }
        }
    }
}