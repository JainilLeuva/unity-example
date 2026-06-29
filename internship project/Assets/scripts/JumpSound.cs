using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpClip;

    private CharacterController controller;
    private bool wasGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        wasGrounded = controller.isGrounded;
    }

    void Update()
    {
        if (wasGrounded && !controller.isGrounded)
        {
            audioSource.PlayOneShot(jumpClip);
        }

        wasGrounded = controller.isGrounded;
    }
}