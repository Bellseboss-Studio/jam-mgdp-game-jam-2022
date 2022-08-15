using System.Collections.Generic;
using GameAudio;
using SystemOfExtras;
using UnityEngine;

public class PlayerSoundSelection : MonoBehaviour, ICheckDependencies
{
  [SerializeField] private CapsuleCollider m_PlayerCollider;
  [SerializeField] private string m_CurrentMaterial = null;
  [SerializeField] private AudioReverbZone m_ReverbZones = null;
  [SerializeField] private string m_CurrentReverbZone = null;
  public void PlayFootstepSound()
  {
    ServiceLocator.Instance.GetService<FootstepSoundSelection>().OnFootstep(m_CurrentMaterial.Replace("(Instance)", "").Trim());
  }
  private void OnTriggerEnter(Collider other)
  {
    m_CurrentReverbZone = other.tag;
    switch (m_CurrentReverbZone)
    {
      case "Room":
        m_ReverbZones.reverbPreset = AudioReverbPreset.Room;
        break;
      
      case "Halls":
        m_ReverbZones.reverbPreset = AudioReverbPreset.Stoneroom;
        break;
      
      case "Bathroom":
        m_ReverbZones.reverbPreset = AudioReverbPreset.Bathroom;
        break;
      
      default:
        m_ReverbZones.reverbPreset = AudioReverbPreset.Off;
        break;
    }
    
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
