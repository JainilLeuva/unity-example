using UnityEngine;

public class gameManager : MonoBehaviour
{
    void Awake()
    {
        // 1. Turn off VSync (VSync overrides targetFrameRate)
        QualitySettings.vSyncCount = 0;

        // 2. Set the target frame rate to 60
        Application.targetFrameRate = 60;

    }
   



}

