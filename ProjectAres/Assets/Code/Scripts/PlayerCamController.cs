using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -90F;
    public float maximumX = 90F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    float rotationY = 0F;
    float rotationX = 0F;

    void Update()
    {
        MouseLook();
    }

    private void MouseLook()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);


            transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.eulerAngles = new Vector3(-rotationY, transform.eulerAngles.y, 0);
        }
    }
}
