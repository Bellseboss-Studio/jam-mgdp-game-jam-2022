using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameAudio
{
       
    public class PlayButtonAnimationSound : MonoBehaviour
    {
        [SerializeField] private AudioClip m_Enter = null;
        [SerializeField] private AudioClip m_Exit = null;
        [SerializeField] private AudioSource m_AudioSource;
        [Range(0f, 0.5f)]
        [SerializeField] private float m_EnterPitchVariation = 0;
        [Range(0f, 0.5f)]
        [SerializeField] private float m_ExitPitchVariation = 0;
        
        private void Start()
        {
            CheckDependencies();
        }

        private void CheckDependencies()
        {
            if (m_AudioSource == null)
            {
                m_AudioSource = GetComponent<AudioSource>();
            }
        }

        public void PlayIntroSoundForButton()
        {
            if (m_Enter == null)
            {
                Debug.Log($"There is no 'Enter' AudioClip associated with this {gameObject.name}");
                return;
            }

            m_AudioSource.pitch = 1f + Random.Range(0f, m_EnterPitchVariation);
            m_AudioSource.PlayOneShot(m_Enter);
        }

        public void PlayExitSoundForButton()
        {
            if (m_Exit == null)
            {
                Debug.Log($"There is no 'Exit' AudioClip associated with this {gameObject.name}");
                return;
            }
            m_AudioSource.pitch = 1f + Random.Range(0f, m_ExitPitchVariation);
            m_AudioSource.PlayOneShot(m_Exit);
        }
    } 
}

