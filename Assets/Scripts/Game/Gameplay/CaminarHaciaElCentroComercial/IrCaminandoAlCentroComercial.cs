using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrCaminandoAlCentroComercial : MonoBehaviour
{
    [SerializeField] private Dialog dialogo;
    private void OnTriggerEnter(Collider other)
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
}
