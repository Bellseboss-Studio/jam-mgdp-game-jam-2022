using UnityEngine;

public class AnimatorControllerAnimations : MonoBehaviour
{
    private bool isInAnimation;

    public bool IsInAnimation => isInAnimation;
    
    public void StartAnimation()
    {
        isInAnimation = true;
    }

    public void FinishedAnimation()
    {
        isInAnimation = false;
    }
}