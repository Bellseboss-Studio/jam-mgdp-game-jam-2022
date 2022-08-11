using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerExtended : MonoBehaviour
    {
        
        public Action OnClickFromPlayer;
        public Action OnItemPressed;
        public Action<int> OnKeyOptionPress;
        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.canceled)
            {
                OnClickFromPlayer?.Invoke();
                //Debug.Log("click");
                
                OnItemPressed?.Invoke();
            }
        }
    
    
        public void OnNumberKeys(InputAction.CallbackContext value)
        {
            if (value.canceled)
            {
                /*Debug.Log($"{value.control.name}");*/
                OnKeyOptionPress?.Invoke(int.Parse(value.control.name));
            }
        }
    }
}