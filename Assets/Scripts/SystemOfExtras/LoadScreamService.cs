using System;
using System.Collections;
using SystemOfExtras;
using UnityEngine;

public class LoadScreamService : MonoBehaviour, ILoadScream
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorControllerAnimations animationController;
    public void Open(Action action)
    {
        //ServiceLocator.Instance.GetService<ITimeService>().StartToCountTime();//Esto debe ir a quien le interece mover el tiempo
        StartCoroutine(LoadScene(true, action));
    }
    
    public void Close(Action action)
    {
        StartCoroutine(LoadScene(false, action));
    }

    private IEnumerator LoadScene(bool isOpen,Action action)
    {
        animator.SetBool("open", isOpen);
        while (!animationController.IsInAnimation)
        {
            yield return new WaitForSeconds(.2f);   
        }
        action?.Invoke();
    }
}