using UnityEngine;

public class CameraBobAndShake : MonoBehaviour
{
    [Header("References")]
    public playrmovement playerMovement; 
    [Header("Walk Settings")]
    public float walkBobSpeed = 14f;      
    public float walkBobAmount = 0.05f;    
    [Header("Sprint Settings")]
    public float sprintBobSpeed = 18f;     
    public float sprintBobAmount = 0.12f;   
    private float timer = 0f;
    private Vector3 defaultPosition;

    void Start()
    {
        

        defaultPosition = transform.localPosition;
    }

    void Update()
    {
      
        bool isMoving = playerMovement.controller.velocity.magnitude > 0.1f;
        bool isGrounded = playerMovement.controller.isGrounded;

        if (isMoving && isGrounded)
        {
           
            float currentSpeed = playerMovement.movespeed == playerMovement.runspeed ? sprintBobSpeed : walkBobSpeed;
            float currentAmount = playerMovement.movespeed == playerMovement.runspeed ? sprintBobAmount : walkBobAmount;

            
            timer += Time.deltaTime * currentSpeed;

            float newY = defaultPosition.y + Mathf.Sin(timer) * currentAmount;

            transform.localPosition = new Vector3(defaultPosition.x, newY, defaultPosition.z);
        }
        else
        {
            
            timer = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPosition, Time.deltaTime * 10f);
        }
    }
}
