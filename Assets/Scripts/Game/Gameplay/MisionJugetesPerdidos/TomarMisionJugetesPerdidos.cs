using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class TomarMisionJugetesPerdidos : InteractiveObjectFather
{
    [SerializeField] private List<InteractiveObject> jugetes;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IStatesMissions>().AddMission(IdMissions.JUGETE);
        foreach (var jugete in jugetes)
        {
            jugete.enabled = true;
        }
    }
}