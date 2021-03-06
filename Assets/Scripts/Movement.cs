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
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrusting();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateLeft()
    {
        if (!leftBooster.isPlaying) leftBooster.Play();
        ApplyRotation(-rotationThrust);
    }

    private void RotateRight()
    {
        ApplyRotation(rotationThrust);
        if (!rightBooster.isPlaying) rightBooster.Play();
    }

    private void StopRotating()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    private void ApplyRotation(float rotationThrust)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }

    void ProcessThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        mainBooster.Stop();
        _audioSource.Stop();
    }

    private void StartThrusting()
    {
        _rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(mainEngine);
        }

        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }
}