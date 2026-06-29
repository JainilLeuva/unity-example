using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwapScene : MonoBehaviour
{
    public bool isplaying = false;
    void Update()
    {
        if (isplaying)
        {
            isplaying = true;
            if (SceneManager.GetActiveScene().name == "mainmenu")
                BGmusic.instance.GetComponent<AudioSource>().Play();
        }
        else
        {
            isplaying = false;
        }



        if (SceneManager.GetActiveScene().name == "stage 1")
        {
            BGmusic.instance.GetComponent<AudioSource>().Pause();
            
        }
       

        if (SceneManager.GetActiveScene().name == "stage 2")
            BGmusic.instance.GetComponent<AudioSource>().Pause();

    }
}
