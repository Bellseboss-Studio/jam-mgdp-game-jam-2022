using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class MissionControlUIView : MonoBehaviour, IStatesMissionsView
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform content;
    [SerializeField] private MissionDetailUiView missionDetailUiViewPrefab;
    private List<MissionDetailUiView> missionDetailUiViewPrefabs;
    private bool isOpen;

    public void Config()
    {
        ServiceLocator.Instance.RegisterService<IStatesMissionsView>(this);
        var listOfMissions = ServiceLocator.Instance.GetService<IStatesMissions>().GetMissionsActive();
        foreach (var missionDetail in listOfMissions)
        {
            var missionDetailUiView = Instantiate(missionDetailUiViewPrefab, content);
            missionDetailUiView.Config(missionDetail);
        }
    }

    public void OpenMissionsTab()
    {
        animator.SetBool("open", isOpen);
        isOpen = !isOpen;
    }
}