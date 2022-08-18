using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class InitializationInScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            
        });
    }
}
