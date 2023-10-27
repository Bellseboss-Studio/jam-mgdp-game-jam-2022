using TMPro;
using UnityEngine;

public class MissionDetailUiView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title, description;

    public void Config(MissionDetail missionDetail)
    {
        title.text = missionDetail.nameOfMission;
        description.text = missionDetail.descriptionOfMission;
        missionDetail.onCompleted += MissionDetailOnOnCompleted;
    }

    private void MissionDetailOnOnCompleted()
    {
        Debug.Log("Mission Completed");
    }
}
