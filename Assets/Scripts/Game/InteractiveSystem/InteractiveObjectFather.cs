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
            Debug.Log(idDialog);
            ActionEventCustom();
            ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound(idDialog);
            return true;
        }

        return false;
    }

    protected abstract void ActionEventCustom();
}