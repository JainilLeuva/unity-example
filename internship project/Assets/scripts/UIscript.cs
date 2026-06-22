using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject gamepenal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        gamepenal.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        gamepenal.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("mainmenu");

    }
 

}
