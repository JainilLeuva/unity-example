using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FPScamara : MonoBehaviour
{
    public Transform playerbody;
    public float yclamp;
    public float sensitivity;
    public float xrotation;
    public Slider sensi_slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        if(sensi_slider != null)
        {
             sensi_slider.value = sensitivity ;
        }
}
    void Update()
    {
        Vector2 mouse = inputmanager.instance.playerinput.Player.Look.ReadValue<Vector2>();
        float mousex = sensitivity * mouse.x * Time.deltaTime;
        float mouseY = sensitivity * mouse.y * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -yclamp, yclamp);
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        playerbody.Rotate(Vector3.up * mousex);
    }
    public void updatesensi(float Newvalue)
    {
        sensitivity = Newvalue;
    }
}
