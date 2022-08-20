using UnityEngine;

public class JugueroMatar : InteractiveObjectFather
{
    protected override void ActionEventCustom()
    {
        Debug.Log("te mate por ser malo");
    }
}