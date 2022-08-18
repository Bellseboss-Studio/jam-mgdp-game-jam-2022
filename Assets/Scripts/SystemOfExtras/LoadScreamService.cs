using System;
using System.Collections;
using UnityEngine;

public class LoadScreamService : MonoBehaviour, ILoadScream
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorControllerAnimations animationController;
    public void Open(Action action)
    {
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