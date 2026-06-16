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
    bool jumping;
    public Vector3 verticalVelocity;
    private float gravityValue = -9.81f;
    private float jumpspeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputmanager.instance.playerinput.Player.Move.performed += Handlemoveinput;
        inputmanager.instance.playerinput.Player.Move.canceled += Handlemoveinput;
        inputmanager.instance.playerinput.Player.Sprint.performed += Handlerunning;
        inputmanager.instance.playerinput.Player.Move.canceled += Handlerunning;
        inputmanager.instance.playerinput.Player.Jump.performed += handlejump;
        inputmanager.instance.playerinput.Player.Jump.canceled+= handlejump;

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

        if (controller.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }
        if(jumping == true && controller.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(gravityValue * -2f * jumpspeed);
        }

        verticalVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        
    }
    void Handlemoveinput(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }
    void Handlerunning(InputAction.CallbackContext context)
    {
        running = context.performed;
    }
    void handlejump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }

    }
    
        
}
