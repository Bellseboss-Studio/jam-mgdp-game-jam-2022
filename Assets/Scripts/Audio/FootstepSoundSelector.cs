using System;
using System.Collections;
using System.Collections.Generic;
using GameAudio;
using UnityEngine;

public class FootstepSoundSelector : MonoBehaviour, ICheckDependencies
{

  [SerializeField] private CapsuleCollider m_PlayerCollider;
  [Tooltip("Drag Footsteps prefabs here")]
  [SerializeField] private List<GameObject> m_FotstepsSurfaces;

  public void PlayFootstepSound()
  {
    m_FotstepsSurfaces[0].SetActive(true);
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.gameObject.tag);
  }

  public void CheckDependencies()
  {
    if (m_PlayerCollider == null)
    {
      m_PlayerCollider = GetComponentInChildren<CapsuleCollider>();
    }
  }
}
