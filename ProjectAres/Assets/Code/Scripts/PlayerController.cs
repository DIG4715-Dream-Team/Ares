using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slidespeed;
    public float mouseSensitivity;
    public Rigidbody rb;

    void Start()
    {
        speed = 4;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxisRaw("Horizontal");
        float locomotion = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(hozMovement * speed, rb.velocity.y, locomotion * speed);
    }
}
