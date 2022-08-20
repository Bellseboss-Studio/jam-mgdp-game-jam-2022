using SystemOfExtras;

public class Banco : InteractiveObjectFather
{
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<ITimeService>().SitUntilNight();
    }
}