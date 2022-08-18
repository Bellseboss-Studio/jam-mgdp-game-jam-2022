using System.Collections.Generic;
using UnityEngine;

public class CambiarAnimacion : InteractiveObjectFather
{
    [SerializeField] private List<Animator> anims;
    protected override void ActionEventCustom()
    {
        foreach (var anim in anims)
        {
            //anim.SetTrigger("idle_alter");
        }
    }
}