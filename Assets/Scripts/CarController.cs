using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 100.0f;
    public float maxSpeed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Sterowanie skrętem za pomocą akcelerometra
        Vector3 turn = new Vector3(0f, Input.acceleration.x * turnSpeed * Time.deltaTime, 0f);
        transform.Rotate(turn);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // Sprawdź, czy ekran jest dotykany
        if (Input.touchCount > 0)
        {
            // Dodaj siłę do przodu, tylko jeśli prędkość jest mniejsza niż maksymalna
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward * moveSpeed);
            }
        }
    }
}
