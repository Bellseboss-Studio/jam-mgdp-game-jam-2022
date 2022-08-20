using UnityEngine;

public abstract class InteractiveObjectFather : MonoBehaviour, IInteractiveObject
{
    [SerializeField] protected Dialog dialogToAction;
    public bool OnAction(string idDialog)
    {
        Debug.Log($"Saw {dialogToAction.Id} == {idDialog} : {dialogToAction.Id == idDialog}");
        if (dialogToAction.Id == idDialog)
        {
            ActionEventCustom();
            return true;
        }

        return false;
    }

    protected abstract void ActionEventCustom();
}