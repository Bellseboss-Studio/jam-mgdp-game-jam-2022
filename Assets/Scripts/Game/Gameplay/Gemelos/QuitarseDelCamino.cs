using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarseDelCamino : InteractiveObjectFather
{
    [SerializeField] private Animator anim;
    protected override void ActionEventCustom()
    {
        Debug.Log("se quitaron");
        anim.SetTrigger("quitar");
    }
}