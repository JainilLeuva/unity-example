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
       
    }
    void OnEnable()
    {
        playerinput.Enable();    // Enables the entire action map asset
        playerinput.UI.Enable(); // Explicitly ensures UI action map is active
    }

    private void OnDisable()
    {
        playerinput.Disable();
        playerinput.UI.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

