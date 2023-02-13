using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float slidespeed;
    public float mouseSensitivity;

    private Rigidbody rb;
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
    }
}
