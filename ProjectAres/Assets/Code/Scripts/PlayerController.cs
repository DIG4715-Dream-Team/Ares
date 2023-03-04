using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slidespeed;
    public float mouseSensitivity;
    public Rigidbody rb;

    public float health;
    public float timeLeft;

    public bool detectable;

    public GameObject bManager;

    public bool died { get; private set; }
    public bool reachedWater { get; private set; }
    void Start()
    {
        bManager = GameObject.FindGameObjectWithTag("bManager");
        speed = 4;
        rb = GetComponent<Rigidbody>();
        health = 20;
        timeLeft = 90;
        detectable = true;
    }

    void Update()
    {
        PauseControl();
    }

    void FixedUpdate()
    {
        PMovement();
        CountDownTimer();
    }

    public void PlayerHit()
    {
        //bManager.GetComponent<ButtonManager>()
    }    

    private void CountDownTimer()
    {
        timeLeft = timeLeft - Time.deltaTime;
    }

    private void PMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.position -= speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.position -= speed * Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.position += speed * Time.deltaTime * transform.right;
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
