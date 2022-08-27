using SystemOfExtras;
using UnityEngine;

public class Scene_02_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() => { });
    }
}
