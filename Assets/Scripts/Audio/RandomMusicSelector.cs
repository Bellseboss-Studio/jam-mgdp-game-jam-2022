using System.Collections.Generic;
using UnityEngine;

namespace GameAudio
{
    public class RandomMusicSelector : MonoBehaviour
    {

        [SerializeField] private AudioSource m_AudioSource = null;

        [SerializeField] private List<AudioClip> m_MusicTracks = new List<AudioClip>();
   
        void Start()
        {
            CheckDependencies();
            int randomTrack = Random.Range(0, m_MusicTracks.Count);
            m_AudioSource.clip = m_MusicTracks[randomTrack];
        }
        
        private void CheckDependencies()
        {
            if (m_AudioSource == null)
            {
                m_AudioSource = GetComponent<AudioSource>();
            }
        }
    }
}
