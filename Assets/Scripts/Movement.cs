using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [FormerlySerializedAs("thrustSpeedEqualizer")] [SerializeField]
    private float thrustVelocity;

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
            _rigidbody.AddRelativeForce(-1, 0, 0);
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
            _rigidbody.AddRelativeForce(Vector3.up * thrustVelocity * Time.deltaTime);
        }
    }
}