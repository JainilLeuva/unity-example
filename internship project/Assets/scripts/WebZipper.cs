using UnityEngine;

public class WebZipper : MonoBehaviour
{
    [Header("Settings")]
    public float maxRange = 25f;       // How far the web can reach
    public float zipSpeed = 20f;       // How fast the player travels
    public float arrivalDistance = 1.5f; // How close before the web disconnects
    public LayerMask grappleLayer;     // The layer assigned to target objects

    [Header("References")]
    public Transform playerBody;       // Drag your main Player GameObject here
    public LineRenderer webVisual;     // Drag your Line Renderer here
    public Transform webLaunchPoint;   // Optional: A point near the bottom of the screen (hand/gun)

    private Vector3 targetPoint;
    private bool isZipping = false;
    private CharacterController controller;
    public GameObject E_image;
    void Start()
    {
        // If webLaunchPoint isn't set, just use the camera's position
        if (webLaunchPoint == null) webLaunchPoint = transform;
        
        // Get the character controller from the player body
        if (playerBody != null)
        {
            controller = playerBody.GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        if (isZipping)
        {
            ExecuteZip();
        }
        else
        {
            CheckForGrappleInput();
        }
    }

    void CheckForGrappleInput()
    {
        // 1. Raycast from the center of the camera forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 2. Check if we hit something on the Grappleable layer within range
        if (Physics.Raycast(ray, out hit, maxRange, grappleLayer))
        {
            // UI Hint: You could change your cursor color here to show they CAN grapple!
            E_image.SetActive(true);
            // 3. If they press 'E', start the zip
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartZip(hit.point);
            }
        }
        else
        {
            E_image.SetActive(false);
        }
    }

    void StartZip(Vector3 destination)
    {
        targetPoint = destination;
        isZipping = true;
        
        // Enable the web visual and set initial positions
        webVisual.enabled = true;
        webVisual.SetPosition(0, webLaunchPoint.position);
        webVisual.SetPosition(1, targetPoint);

        // NOTE: If you have a normal movement script, you should disable it here
        // so it doesn't fight against the zipping motion (e.g., playerMovement.enabled = false;)
    }

    void ExecuteZip()
    {
        // 1. Update the web visual so it sticks to the hand and target as you move
        webVisual.SetPosition(0, webLaunchPoint.position);
        webVisual.SetPosition(1, targetPoint);

        // 2. Calculate direction and move the player
        Vector3 direction = (targetPoint - playerBody.position).normalized;
        
        if (controller != null)
        {
            // Move using CharacterController
            controller.Move(direction * zipSpeed * Time.deltaTime);
        }
        else
        {
            // Fallback Transform movement if you aren't using a CharacterController yet
            playerBody.position += direction * zipSpeed * Time.deltaTime;
        }

        // 3. Check if we have arrived at the target object
        float distanceToTarget = Vector3.Distance(playerBody.position, targetPoint);
        if (distanceToTarget <= arrivalDistance)
        {
            StopZip();
        }
    }

    void StopZip()
    {
        isZipping = false;
        webVisual.enabled = false;
        // Turn off the web
        

        // RE-ENABLE your normal movement script here!
        // e.g., playerMovement.enabled = true;
    }
}
