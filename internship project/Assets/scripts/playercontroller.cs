using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    playerinputss playerinput;
    public Vector2 moveinput;
    public bool running;

    private void Awake()
    {
        playerinput = new playerinputss();     
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
        playerinput.Player.Move.performed += onmove;
        playerinput.Player.Move.canceled += onmove;
        playerinput.Player.Sprint.performed += onrunning;
        playerinput.Player.Sprint.canceled += onrunning;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void onmove(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }
    void onrunning(InputAction.CallbackContext context)
    {
        running = context.performed;
    }
}
