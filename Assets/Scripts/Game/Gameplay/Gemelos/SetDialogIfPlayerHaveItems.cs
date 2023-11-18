using System.Linq;
using SystemOfExtras;
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
        var countOfIngredients = ServiceLocator.Instance.GetService<IStatesMissions>().GetMissionsActive();
        var count = 0;
        var countOfIngredientsLength = 0;
        foreach (var missionDetail in countOfIngredients.Where(missionDetail => !string.IsNullOrEmpty(missionDetail.ingredientName)))
        {
            countOfIngredientsLength++;
            if (missionDetail.IsCompleted)
            {
                count++;
            }
        }
        Debug.Log("count: " + count);
        Debug.Log("countOfIngredientsLength: " + countOfIngredientsLength);
        return countOfIngredientsLength == count;
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