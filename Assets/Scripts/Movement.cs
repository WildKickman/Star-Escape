using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustPower = 0f;
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float airRollSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessADInput();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime * 10);
        }
    }

    void ProcessADInput()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false)
        {
            ApplyRotation(Vector3.back, rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.A)  && Input.GetKey(KeyCode.D) == false)
        {
            ApplyRotation(Vector3.forward, rotationSpeed);
        }
    }


    void ApplyRotation(Vector3 direction, float speed)
    {
        rb.freezeRotation = true;
        transform.Rotate(direction * Time.deltaTime * speed);
        rb.freezeRotation = false;
    }
}
