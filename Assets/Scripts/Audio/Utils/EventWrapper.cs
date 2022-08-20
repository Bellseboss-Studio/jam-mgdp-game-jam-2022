using System.Collections;
using System.Collections.Generic;
using GameAudio;
using SystemOfExtras;
using UnityEngine;

public class EventWrapper : MonoBehaviour
{
    [SerializeField] private string m_AudioObject = null;
    
    public void PlaySound()
    {
        ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound(m_AudioObject);
    }
}
