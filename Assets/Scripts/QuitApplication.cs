using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuitApplication : MonoBehaviour
    {
        private void Update()
        {
            ApplyQuitApplication();
        }

        private void ApplyQuitApplication()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("We pushed escape");
                Application.Quit();
            }
        }
    }
}