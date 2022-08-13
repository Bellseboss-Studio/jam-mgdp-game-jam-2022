using System.Collections.Generic;
using GameAudio;
using SystemOfExtras;
using UnityEngine;

public class FootstepSoundSelector : MonoBehaviour, ICheckDependencies
{
  [SerializeField] private CapsuleCollider m_PlayerCollider;
  [Tooltip("Drag Footsteps prefabs here")]
  [SerializeField] private List<GameObject> m_FotstepsSurfaces;
  [SerializeField] private string m_CurrentMaterial = null;
  
  public void PlayFootstepSound()
  {
    //m_FotstepsSurfaces[0].SetActive(true);
    ServiceLocator.Instance.GetService<FootstepSoundSelection>().OnFootstep(m_CurrentMaterial.Replace("(Instance)", "").Trim());
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
  
  private void Update()
  {
    Ray ray = new Ray(this.transform.position,Vector3.down);
    RaycastHit hit;
    if (Physics.Raycast(ray,out hit, 10f ))
    {
      if (m_CurrentMaterial != hit.transform.gameObject.GetComponent<MeshRenderer>().material.name)
      {
        Debug.Log(hit.transform.gameObject.GetComponent<MeshRenderer>().material.name);
        m_CurrentMaterial = hit.transform.gameObject.GetComponent<MeshRenderer>().material.name;
      }
                
    }
  }
}
