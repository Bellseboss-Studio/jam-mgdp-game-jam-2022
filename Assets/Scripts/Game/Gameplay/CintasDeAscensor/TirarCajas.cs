using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarCajas : InteractiveObjectFather
{
    [SerializeField] private Animator anim;
    protected override void ActionEventCustom()
    {
        anim.SetTrigger("caer");
    }
}
