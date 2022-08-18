using System.Collections.Generic;
using GameAudio;
using SystemOfExtras;
using UnityEngine;

namespace GameAudio
{
  public class PlayerSoundSelection : MonoBehaviour, ICheckDependencies
  {
    [SerializeField] private CapsuleCollider m_PlayerCollider;
    [SerializeField] private string m_CurrentMaterial = null;
    
    public void PlayFootstepSound()
    {
      ServiceLocator.Instance.GetService<FootstepSoundSelection>().OnFootstep(m_CurrentMaterial.Replace("(Instance)", "").Trim());
    }
    
    public void CheckDependencies()
    {
      if (m_PlayerCollider == null)
      {
        m_PlayerCollider = GetComponentInChildren<CapsuleCollider>();
      }
    }
    private void Update()
    {
      Ray ray = new Ray(this.transform.position,Vector3.down);
      RaycastHit hit;
      if (Physics.Raycast(ray,out hit, 10f ))
      {
        if (m_CurrentMaterial != hit.transform.gameObject.GetComponent<MeshRenderer>().material.name)
        {
          //Debug.Log(hit.transform.gameObject.GetComponent<MeshRenderer>().material.name);
          m_CurrentMaterial = hit.transform.gameObject.GetComponent<MeshRenderer>().material.name;
        }
                  
      }
    }
  }
}

