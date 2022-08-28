using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Rules_Cinematic : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    private void Start()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds((float)timeline.duration);
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
}
