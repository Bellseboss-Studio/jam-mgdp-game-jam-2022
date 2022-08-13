using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace GameAudio
{
    public class PlayButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] protected TypeOfButton m_TypeOfButton = default;
        [Range(0f,1f)]
        [SerializeField] protected float m_ButtonSoundVolume = 0;
        
        [SerializeField] protected TypeOfButton m_WhooshSound = TypeOfButton.WhooshSfx;
        [Range(0f,0.5f)]
        [SerializeField] protected float m_WhooshVolume = 0;
        
        public virtual void OnButtonTappedSound()
        {
            if(UISounds.Instance.isActiveAndEnabled)
            {
                UISounds.Instance.OnButtonTappedSound(m_TypeOfButton.ToString(), m_ButtonSoundVolume);
            }
            else
            {
                Debug.Log("No instance of UISounds is present in this scene.");
            }
        }
        
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            UISounds.Instance.OnButtonTappedSound(m_WhooshSound.ToString(), m_WhooshVolume);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            return;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonTappedSound();
        }
    }
}