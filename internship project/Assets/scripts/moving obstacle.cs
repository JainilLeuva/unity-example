using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float floatHeight = 1f;
    [SerializeField] private float floatSpeed = 2f;

    private Vector3 startPosition;

    private void Start()
    {
        // Store the initial position
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate smooth up and down movement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Apply the new position while keeping X and Z unchanged
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}