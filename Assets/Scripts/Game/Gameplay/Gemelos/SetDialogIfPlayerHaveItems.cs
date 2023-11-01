using UnityEngine;

public class SetDialogIfPlayerHaveItems : InteractiveObject
{
    [SerializeField] private Dialog dialogOk, dialogNo;
    [SerializeField] private SetToGoodEnding setToGoodEnding;
    [SerializeField] private SetToBadEnding setToBadEnding;
        protected override void StartCustom()
    {
        base.StartCustom();
        if (CheckIfPlayerHaveItems())
        {
            ChangeAllComponentsToGoodEnd();
        }
        else
        {
            ChangeAllComponentsToBadEnd();
        }
    }

    private bool CheckIfPlayerHaveItems()
    {
        return false;//refactor here to check if player have items
    }

    private void ChangeAllComponentsToBadEnd()
    {
        idDialog = dialogNo;
        setToBadEnding.Change();
    }

    private void ChangeAllComponentsToGoodEnd()
    {
        idDialog = dialogOk;   
        setToGoodEnding.Change();
    }
}