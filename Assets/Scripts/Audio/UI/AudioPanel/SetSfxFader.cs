using UnityEngine;

namespace GameAudio
{
    public class SetSfxFader : SetFaderLevel
    {
        private void Awake()
        {
            OnEnable();
        }
        public override void SetVolume(float sliderValue)
        {
            m_Mixer.SetFloat(m_FaderToControl, Mathf.Log10(sliderValue) * 20);
            UIPerdurableValues.SfxFaderValue = m_Slider.value;
        }

        private void OnEnable()
        {
            m_Slider.value = UIPerdurableValues.SfxFaderValue;
        }
    }
}