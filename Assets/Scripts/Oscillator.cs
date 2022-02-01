using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Oscillator : MonoBehaviour
    {
        Vector3 startingPosition;
        [SerializeField] Vector3 movementVector;

        [SerializeField] [Range(0, 1)] float movementFactor;
        [SerializeField] float period = 2f;

        private void Start()
        {
            startingPosition = transform.position;
        }

        private void Update()
        {
            float cycles = Time.time / period;

            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(tau * cycles);
            movementFactor = (rawSinWave + 1f) / 2f;
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}