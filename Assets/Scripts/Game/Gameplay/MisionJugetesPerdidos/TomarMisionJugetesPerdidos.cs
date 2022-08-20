using System.Collections.Generic;
using UnityEngine;

public class TomarMisionJugetesPerdidos : InteractiveObjectFather
{
    [SerializeField] private List<InteractiveObject> jugetes;
    protected override void ActionEventCustom()
    {
        foreach (var jugete in jugetes)
        {
            jugete.enabled = true;
        }
    }
}