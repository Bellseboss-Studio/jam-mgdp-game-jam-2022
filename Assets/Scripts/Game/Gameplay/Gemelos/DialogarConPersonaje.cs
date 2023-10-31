using System;
using System.Collections;
using UnityEngine;

public class DialogarConPersonaje : InteractiveObjectFather
{
    [SerializeField] private Animator anim;
    protected override void ActionEventCustom()
    {
        anim.SetBool("dialog",true);
        StartCoroutine(Talk());
    }

    private IEnumerator Talk()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("dialog",false);
    }
}