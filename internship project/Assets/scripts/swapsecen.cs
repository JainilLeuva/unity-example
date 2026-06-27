using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwapScene : MonoBehaviour
{
    void Update()
    {
       
        if (SceneManager.GetActiveScene().name == "stage 1")
            BGmusic.instance.GetComponent<AudioSource>().Play();
        if (SceneManager.GetActiveScene().name == "stage 1")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
        //BGmusic.instance.GetComponent<AudioSource>().Play();
        if (SceneManager.GetActiveScene().name == "stage 2")
            BGmusic.instance.GetComponent<AudioSource>().Pause();

    }
}
