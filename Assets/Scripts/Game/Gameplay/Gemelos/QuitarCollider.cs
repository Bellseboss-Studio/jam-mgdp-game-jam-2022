using UnityEngine;

public class QuitarCollider : InteractiveObjectFather
{
    [SerializeField] private Collider colliderQuitar, colliderPoner;
    protected override void ActionEventCustom()
    {
        colliderQuitar.enabled = false;
        colliderPoner.enabled = true;
    }
}