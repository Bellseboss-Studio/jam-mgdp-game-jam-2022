using System;
using System.Collections.Generic;
using Unity.UI;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameAudio
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_UIElements;
        private Dictionary<string, GameObject> m_UiElementsDictionary = new Dictionary<string, GameObject>();
        private bool m_IsGamePaused;
        private void Start()
        {
            ServiceLocator.Instance.RegisterService(this);
            foreach (GameObject t in m_UIElements)
            {
                
                m_UiElementsDictionary.Add(t.gameObject.name, t);
            }
        }

        private void Update()
        {
            ActivateUIPannel("Pause");
        }

        public void ActivateUIPannel(string panelOb)
        {
            if (m_UiElementsDictionary.ContainsKey(panelOb))
            {
                m_UiElementsDictionary[panelOb].SetActive(true);
                Debug.Log("Changosssss");
            }

        }
        public void HideUI()
        {
            foreach (GameObject panel in m_UIElements)
            {
                panel.gameObject.SetActive(false);
                Debug.Log("Paneles: " + panel.gameObject.name);
            }
        }
    }
}
   
