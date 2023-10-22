using UnityEngine;

public class StealFlour : InteractiveObjectFather
{
    [SerializeField] private Pastelero pastelero;
    [SerializeField] private Dialog newDialog;
    protected override void ActionEventCustom()
    {
        pastelero.SetDialogo(newDialog);
    }
}