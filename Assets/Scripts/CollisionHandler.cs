using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float levelLoadDelay = 0f;
        [SerializeField] AudioClip crash;
        [SerializeField] AudioClip success;


        AudioSource _audioSource;

        private bool isTransitioning = false;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Fuel":
                    Debug.Log("You picked up fuel");
                    break;
                case "Finish":
                    Debug.Log("Congratulations you made it to the Finish!!");
                    StartSuccessSequence();
                    break;
                case "Friendly":
                    Debug.Log("This is friendly!");
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }

        void StartSuccessSequence()
        {
            if (!_audioSource.isPlaying) _audioSource.PlayOneShot(success);
            else _audioSource.Stop();
            GetComponent<Movement>().enabled = false;
            Invoke("NextLevel", levelLoadDelay);
        }

        void StartCrashSequence()
        {
            // todo add SFX upon crash
            if (!_audioSource.isPlaying) _audioSource.PlayOneShot(crash);
            else _audioSource.Stop();
            // todo add particle effect upon crash
            GetComponent<Movement>().enabled = false;
            Invoke(nameof(ReloadLevel), levelLoadDelay);
        }

        void NextLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            var nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }

        void ReloadLevel()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}