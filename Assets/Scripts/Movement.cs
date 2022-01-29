using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float rotationThrust;

    [SerializeField] float mainThrust;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateThrust(-Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateThrust(Vector3.forward);
        }
    }

    private void RotateThrust(Vector3 vector)
    {
        transform.Rotate(vector * rotationThrust * Time.deltaTime);
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }
}