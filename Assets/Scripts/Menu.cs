using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject player;
    public GameObject airplane;
    public void Play()
    {
        gameObject.SetActive(false);
        player.SetActive(true);
        airplane.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
