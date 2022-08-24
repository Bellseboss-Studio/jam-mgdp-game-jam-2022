using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_UIElements;
    private Dictionary<string, GameObject> m_UiElementsDictionary;

    private void Start()
    {
        foreach (GameObject gameO in m_UIElements)
        {
            m_UiElementsDictionary.Add(gameO.name, gameO);
        }
    }

    public void ActivateUIPannel(string go)
    {
        foreach (GameObject panel in m_UIElements)
        {
            panel.SetActive(false);
        }

        if (m_UIElements.Contains(m_UiElementsDictionary[go]))
        {
            m_UiElementsDictionary[go].SetActive(true);
        }
        else
        {
            return;
        }


    }
}
    
   
