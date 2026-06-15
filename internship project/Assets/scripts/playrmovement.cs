using UnityEngine;
using UnityEngine.InputSystem;

public class playrmovement : MonoBehaviour
{
    public CharacterController controller;
    Vector2 moveinput;
    public float runspeed = 5f;
    public float walkspeed = 3f;
    public float movespeed;
    bool running;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputmanager.instance.playerinput.Player.Move.performed += Handlemoveinput;
        inputmanager.instance.playerinput.Player.Move.canceled += Handlemoveinput;
        inputmanager.instance.playerinput.Player.Sprint.performed += Handlerunning;
        inputmanager.instance.playerinput.Player.Move.canceled += Handlerunning;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movedir = transform.right * moveinput.x + transform.forward * moveinput.y;
        if (running == true)
        {
            movespeed = runspeed;
        }
        else
        {
            movespeed = walkspeed;
        }
        controller.Move(movedir.normalized * movespeed * Time.deltaTime);
    }
    void Handlemoveinput(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }
    void Handlerunning(InputAction.CallbackContext context)
    {
        running = context.performed;
    }
        
}
