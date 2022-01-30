using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor

    // CACHE - e.g references for readability of speed

    // STATE - private instance (member variables)

    Rigidbody _rigidbody;
    private AudioSource _audioSource;

    [SerializeField] float rotationThrust;
    [SerializeField] float mainThrust;
    [SerializeField] AudioClip mainEngine;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
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
            RotateThrust(-rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateThrust(rotationThrust);
        }
    }

    private void RotateThrust(float rotationThrust)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!_audioSource.isPlaying) _audioSource.PlayOneShot(mainEngine);
            else _audioSource.Stop();
        }
    }
}