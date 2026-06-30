using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    void Awake()
    {
        // 1. Singleton pattern: Prevents duplicate AudioManagers from spawning
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object alive across scenes
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Destroys duplicates
            return;
        }
    }

    void OnEnable()
    {
        // 2. Listen to Unity's scene loading events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 3. This runs automatically every time a new scene loads
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = scene.name;

        // Check if the current scene should have menu music
        if (currentScene == "mainmenu" || currentScene == "leve_scene")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        // Check if the current scene is a gameplay level
        else if (currentScene == "stage 1" || currentScene == "stage 2")
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
