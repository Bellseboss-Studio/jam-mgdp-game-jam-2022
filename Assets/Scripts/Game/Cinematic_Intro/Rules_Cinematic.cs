using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Rules_Cinematic : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject clickToContinue;

    private void Start()
    {
        StartCoroutine(LoadGame());
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Cursor Loked");
    }

    private IEnumerator LoadGame()
    {
        
        yield return new WaitForSeconds((float)timeline.duration);
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
    
    public void PauseTimeLine()
    {
        timeline.Pause();
        clickToContinue.gameObject.SetActive(true);
    }
    
    public void ContinueTimeLine()
    {
        timeline.Resume();
        clickToContinue.gameObject.SetActive(false);
    }
}
