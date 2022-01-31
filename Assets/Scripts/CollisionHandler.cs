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
        [SerializeField] ParticleSystem crashParticles;
        [SerializeField] ParticleSystem successParticles;

        AudioSource _audioSource;


        private bool isTransitioning = false;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (isTransitioning) return;
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
            isTransitioning = true;
            _audioSource.Stop();
            _audioSource.PlayOneShot(success);
            successParticles.Play();
            GetComponent<Movement>().enabled = false;
            Invoke("NextLevel", levelLoadDelay);
        }

        void StartCrashSequence()
        {
            isTransitioning = true;
            // todo add SFX upon crash
            _audioSource.Stop();
            _audioSource.PlayOneShot(crash);
            // todo add particle effect upon crash
            crashParticles.Play();
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