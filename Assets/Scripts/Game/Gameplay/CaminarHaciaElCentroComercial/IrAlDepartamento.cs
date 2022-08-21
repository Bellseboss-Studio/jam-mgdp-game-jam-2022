using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlDepartamento : MonoBehaviour
{ 
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}