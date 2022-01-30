using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CollisionHandler : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Fuel":
                    Debug.Log("You picked up fuel");
                    break;
                case "Finish":
                    Debug.Log("Congratulations you made it to the Finish!!");
                    NextLevel();
                    break;
                case "Friendly":
                    Debug.Log("This is friendly!");
                    break;
                default:
                    Debug.Log("Sorry you blew up");
                    ReloadLevel();
                    break;
            }
        }

        private void NextLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            var nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

        private static void ReloadLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}