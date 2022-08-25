using System;
using System.Collections;
using System.Collections.Generic;
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

public class GemelosCinematicaTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Egnter");
        }
    }
}
