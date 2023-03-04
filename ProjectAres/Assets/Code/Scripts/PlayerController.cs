using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float slideForce;
    private float mouseSensitivity { get; }
    public Rigidbody rb;

    public int Health { get; private set; }

    public bool died { get; private set; }
    public bool reachedWater { get; private set; }
    public bool gameOver { get; private set; }
    void Start()
    {
        slideForce = 10;
        speed = 4;
        rb = GetComponent<Rigidbody>();
        Health = 20;
    }

    void Update()
    {
        PauseControl();
        if (Input.GetKeyDown(KeyCode.J))
        {
            PushBuff();
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
        //TestingFunction();
    }

    public void TestingFunction()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            reachedWater = true;
            gameOver = true;
        }
    }

    public void HealthManagement(int amount)
    {
        Health = Health + amount;

        if (Health <= 0)
        {
            died = true;
        }
    }

    public void PushBuff()
    {
        rb.AddRelativeForce(Vector3.forward * slideForce, ForceMode.Impulse);
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }

    private void PauseControl()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
    }
}
