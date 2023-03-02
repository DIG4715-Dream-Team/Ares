using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slidespeed;
    public float mouseSensitivity;
    public Rigidbody rb;

    public float Health;
    public float Score;
    void Start()
    {
        speed = 4;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.position -= transform.forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.position -= transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.position += transform.right * Time.deltaTime * speed;
        }
    }
}
