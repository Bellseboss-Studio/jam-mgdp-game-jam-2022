using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/AskToItemToPlayer")]
public class AskToItemToPlayer : Dialog
{
    private string _baseDialog = "";
    public void ActualizeTimeDialog(string getTime)
    {
        if (_baseDialog == "")
        {
            _baseDialog = dialogText;
        }

        dialogText = $"{_baseDialog} {getTime}";
    }
}