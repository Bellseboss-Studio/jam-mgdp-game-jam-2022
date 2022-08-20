using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/TimeDialog")]
public class TimeDialog : Dialog
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