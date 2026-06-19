using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playrmovement : MonoBehaviour
{
    public CharacterController controller;
    public Vector2 moveinput;
    public float runspeed = 5f;
    public float walkspeed = 3f;
    public float movespeed;
    bool running;
    bool jumping;
    
    [Header("Physics Settings")]
    public Vector3 verticalVelocity;
    private float gravityValue = -10.81f;
    public float jumpspeed = 2f;

   

    void Start()
    {
        inputmanager.instance.playerinput.Player.Move.performed += Handlemoveinput;
        inputmanager.instance.playerinput.Player.Move.canceled += Handlemoveinput;

        inputmanager.instance.playerinput.Player.Sprint.performed += Handlerunning;
        
        inputmanager.instance.playerinput.Player.Sprint.canceled += Handlerunning;

        inputmanager.instance.playerinput.Player.Jump.performed += handlejump;
       
    }

    // Update is called once per frame
    void Update()
    {
        //setting velocity
        if (controller.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        //jumping
        if (jumping && controller.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(gravityValue * -2f * jumpspeed * Time.deltaTime);
        }       
        jumping = false;

        //movement
        Vector3 movedir = transform.right * moveinput.x + transform.forward * moveinput.y;
        if (running == true)
        {
            movespeed = runspeed;
        }
        else
        {
            movespeed = walkspeed;
        }       
        verticalVelocity.y += gravityValue * Time.deltaTime;     
        Vector3 horizontalMove = movedir.normalized * movespeed;
        Vector3 finalMovement = horizontalMove + verticalVelocity;
        controller.Move(finalMovement * Time.deltaTime);    
      
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
    }
   
}