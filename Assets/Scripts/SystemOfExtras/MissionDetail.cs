using System;

[Serializable]
public class MissionDetail
{
    public Action onCompleted;
    public IdMissions idMissions;
    public string nameOfMission;
    public string descriptionOfMission;
    public string ingredientName;
    private bool _isCompleted;
    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (value)
            {
                onCompleted?.Invoke();
            }
            _isCompleted = value;
        }
    }
}