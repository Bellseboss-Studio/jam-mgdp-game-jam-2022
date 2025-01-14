﻿using UnityEngine;

namespace SystemOfExtras
{
    public class Installer : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            new PlayFabCustom();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}