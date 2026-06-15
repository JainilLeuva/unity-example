using Unity.Mathematics;
using UnityEngine;

public class FPScamara : MonoBehaviour
{
    public Transform playerbody;
    public float yclamp;
    public float sensitivity;
    float xrotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = inputmanager.instance.playerinput.Player.Look.ReadValue<Vector2>();
        float mousex = sensitivity * mouse.x * Time.deltaTime;
        float mouseY = sensitivity * mouse.y * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = math.clamp(xrotation, -yclamp, yclamp);
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        playerbody.Rotate(Vector3.up * mousex);
    }
}
