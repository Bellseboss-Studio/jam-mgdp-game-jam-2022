using SystemOfExtras;
using UnityEngine;

public class Banco : InteractiveObjectFather
{
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<ITimeService>().SitUntilNight();
    }
}
