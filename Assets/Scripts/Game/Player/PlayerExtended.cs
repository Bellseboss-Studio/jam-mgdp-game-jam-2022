using System;
using GameAudio;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerExtended : MonoBehaviour
    {
        public Action OnClickFromPlayer;
        public Action OnItemPressed;
        public Action<int> OnKeyOptionPress;
        private bool m_IsPaused;
        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.canceled)
            {
                OnClickFromPlayer?.Invoke();
                //Debug.Log("click");
                
                OnItemPressed?.Invoke();
            }
        }

        public void Start()
        {
            ServiceLocator.Instance.GetService<UIControl>().SetBackPausePanelCallback(ActivateUIBool);
        }

        public void OnNumberKeys(InputAction.CallbackContext value)
        {
            if (value.canceled)
            {
                OnKeyOptionPress?.Invoke(int.Parse(value.control.name));
            }
        }

        public void ActivateUIBool()
        {
            m_IsPaused = false;
            ServiceLocator.Instance.GetService<UIControl>().HideUI();
            ServiceLocator.Instance.GetService<MusicSystem>().UnpauseMixer();
            ServiceLocator.Instance.GetService<IMediatorPlayer>().LockPlayer(false);

        }

        public void ActivateUI(InputAction.CallbackContext value)
        {
            if (value.canceled)
            {
                m_IsPaused = !m_IsPaused;
                if (m_IsPaused)
                {
                    ServiceLocator.Instance.GetService<UIControl>().ActivateUIPannel("Pause");
                    ServiceLocator.Instance.GetService<MusicSystem>().SetPauseMixer();
                    ServiceLocator.Instance.GetService<IMediatorPlayer>().LockPlayer(true);
                }
                else
                {
                    ServiceLocator.Instance.GetService<UIControl>().HideUI();
                    ServiceLocator.Instance.GetService<MusicSystem>().UnpauseMixer();
                    ServiceLocator.Instance.GetService<IMediatorPlayer>().LockPlayer(false);
                }
            }
            
        }
        
    }
}