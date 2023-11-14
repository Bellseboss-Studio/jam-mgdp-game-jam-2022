using System.Collections;
using GameAudio;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private float m_delayTime = 0.5f;
    [SerializeField] private bool isReset;
    public void OnQuitGameClicked()
    {
        StartCoroutine(nameof(TerminateGameSequence));
    }

    IEnumerator TerminateGameSequence()
    {
        yield return new WaitForSeconds(m_delayTime);
        if (isReset)
        {
            //reset game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ServiceLocator.Instance.GetService<UIControl>().HideUI();
            ServiceLocator.Instance.GetService<MusicSystem>().UnpauseMixer();
        }
        else
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
