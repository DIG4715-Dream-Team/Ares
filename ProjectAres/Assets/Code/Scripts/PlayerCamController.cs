using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX;
    public float sensitivityY;
    public float minimumX;
    public float maximumX;
    public float minimumY;
    public float maximumY;
    float rotationY;
    float rotationX;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        MouseLook();
    }

    void FixedUpdate()
    {
        //player.GetComponent<PlayerController>().rb.rotation = Quaternion.Euler(Rigidbody.rotation.eulerAngles + )

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
            player.GetComponent<PlayerController>().rb.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
    }
}
