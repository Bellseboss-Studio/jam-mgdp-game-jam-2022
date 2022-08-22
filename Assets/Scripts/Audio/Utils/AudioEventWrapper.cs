using SystemOfExtras;
using UnityEngine;

namespace GameAudio
{
    public class AudioEventWrapper : MonoBehaviour
    {
        [SerializeField] private string m_AudioObject = null;

        public void PlaySound()
        {
            ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound(m_AudioObject);
        }
    }
}
