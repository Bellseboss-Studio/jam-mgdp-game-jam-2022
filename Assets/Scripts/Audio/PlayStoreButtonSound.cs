using UnityEngine;


namespace GameAudio
{
    public class PlayStoreButtonSound : PlayButtonSound
    {
       
        [SerializeField] private GameObject m_InsufficientMoneyOverlay = null;
        [SerializeField] private string m_NameOfButton = null;
        
        public override void OnButtonTappedSound()
        {
            if(UISounds.Instance.isActiveAndEnabled && !m_InsufficientMoneyOverlay.activeInHierarchy)
            {
                UISounds.Instance.OnButtonTappedSound(m_TypeOfButton.ToString(), 1f);
            } else if(UISounds.Instance.isActiveAndEnabled && m_InsufficientMoneyOverlay.activeInHierarchy)
            {
                UISounds.Instance.OnButtonTappedSound(m_NameOfButton, 1f);
            }
            else
            {
                Debug.Log("No instance of UISounds is present in this scene.");
            }
        }
        
    }
}