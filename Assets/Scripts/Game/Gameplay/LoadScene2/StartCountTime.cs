using SystemOfExtras;
using UnityEngine;

public class StartCountTime : MonoBehaviour
{
    private void Start()
    {
        ServiceLocator.Instance.GetService<ITimeService>().StartToCountTime();
    }
}