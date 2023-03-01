using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slidespeed;
    public float mouseSensitivity;
    private Rigidbody rb;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -360F;
    public float maximumY = 360F;
    float rotationY = 0F;
    float rotationX = 0F;
    void Start()
    {
        speed = 4;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hozMovement = Input.GetAxisRaw("Horizontal");
        float locomotion = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(hozMovement * speed, rb.velocity.y, locomotion * speed);

        //MouseLook();
    }

    private void MouseLook()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);


            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
