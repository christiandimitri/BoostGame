using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

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
            _rigidbody.AddRelativeForce(- 1, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddRelativeForce(1, 0, 0);
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(0, 10, 0);
            Debug.Log("Space button Hit");
        }
    }
}