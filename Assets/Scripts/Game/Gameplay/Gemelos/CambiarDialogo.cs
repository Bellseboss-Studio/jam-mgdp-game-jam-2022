using UnityEngine;

public class CambiarDialogo : InteractiveObjectFather
{
    [SerializeField] private InteractiveObject interactiveTarger;
    [SerializeField] private Dialog dialogToChange;
    protected override void ActionEventCustom()
    {
        interactiveTarger.SetDialogo(dialogToChange);
    }
}