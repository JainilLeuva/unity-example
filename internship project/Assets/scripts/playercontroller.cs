using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    playerinputss playerinput;
    public Vector2 moveinput;
    public bool running;

    private void Awake()
    {
        playerinput = new ();
        playerinput.Enable();
    }
    private void OnDisable()
    {
        playerinput.Disable();
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
