using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class InstallerExplicitCinematicaIntro : MonoBehaviour
{
    [SerializeField] private LoadScreamService load;
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.RegisterService<ILoadScream>(load);
        DontDestroyOnLoad(gameObject);
    }
}
