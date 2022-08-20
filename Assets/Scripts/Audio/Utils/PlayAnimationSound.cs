using System;
using System.Collections;
using System.Collections.Generic;
using GameAudio;
using UnityEngine;


public class PlayAnimationSound : MonoBehaviour, ICheckDependencies
{
    [SerializeField] private AudioClip m_Sound = null;
    [SerializeField] private AudioSource m_As = null;
    
    private void Start()
    {
       CheckDependencies();
    }

    public void PlaySound()
    {
        m_As.PlayOneShot(m_Sound);
    }
    public void CheckDependencies()
    {
        if (m_As == null)
        {
            m_As = GetComponentInChildren<AudioSource>();
        }
    }
}
