using SystemOfExtras;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{

    public void GoToCredits()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(7);
        });
    }
}