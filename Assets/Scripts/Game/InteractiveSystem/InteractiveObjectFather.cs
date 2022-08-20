using GameAudio;
using SystemOfExtras;
using UnityEngine;

public abstract class InteractiveObjectFather : MonoBehaviour, IInteractiveObject
{
    [SerializeField] protected Dialog dialogToAction;
    public bool OnAction(string idDialog)
    {
    
        if (dialogToAction != null && dialogToAction.Id == idDialog)
        {
            ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound(idDialog);
            Debug.Log(idDialog);
            ActionEventCustom();
            return true;
        }

        return false;
    }

    protected abstract void ActionEventCustom();
}