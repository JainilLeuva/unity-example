using UnityEngine;

public class TeleportToStart : MonoBehaviour
{
    [Header("Player Reference")]
    public Transform player;

    [Header("Respawn Point")]
    public Transform respawnPoint;

    private CharacterController characterController;

    private void Start()
    {
        if (player != null)
        {
            characterController = player.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (player == null || respawnPoint == null)
            return;

        // Disable CharacterController before teleporting
        if (characterController != null)
            characterController.enabled = false;

        player.position = respawnPoint.position;
        player.rotation = respawnPoint.rotation;

        // Re-enable CharacterController
        if (characterController != null)
            characterController.enabled = true;
    }
}