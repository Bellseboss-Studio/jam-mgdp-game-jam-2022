using System;
using System.Collections;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace StarterAssets.Utilities
{
    public class SaltarCinematica : MonoBehaviour
    {
        [SerializeField] private GameObject pressButtonForSkipCinematic;
        [SerializeField] private float seconds;
        private bool _canSkip = false;

        private void Start()
        {
            pressButtonForSkipCinematic.SetActive(false);
        }

        private void Update()
        {
            if (_canSkip && Keyboard.current.enterKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                StopAllCoroutines();
                StartCoroutine(ShowTextForSeconds());
            }
        }

        private IEnumerator ShowTextForSeconds()
        {
            pressButtonForSkipCinematic.SetActive(true);
            _canSkip = true;
            yield return new WaitForSeconds(seconds);
            pressButtonForSkipCinematic.SetActive(false);
            _canSkip = false;
        }
    }
    
}