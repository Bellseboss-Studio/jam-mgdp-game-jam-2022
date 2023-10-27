using System;
using SystemOfExtras;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    private void Start()
    {
        ServiceLocator.Instance.GetService<IMediatorPlayer>().HidePlayer();
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() => { });
    }

    public void GoToCredits()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(7);
        });
    }
}