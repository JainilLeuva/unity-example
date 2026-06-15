using UnityEngine;

public class inputmanager : MonoBehaviour
{
    public static inputmanager instance;
    public playerinputss playerinput;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        playerinput = new();
        playerinput.Enable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

