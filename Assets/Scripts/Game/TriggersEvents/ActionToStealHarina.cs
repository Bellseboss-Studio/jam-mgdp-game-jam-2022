using UnityEngine;

public class ActionToStealHarina : InteractiveObjectFather
{
    [SerializeField] private GameObject[] paredes;
    protected override void ActionEventCustom()
    {
        foreach (var pared in paredes)
        {
            pared.SetActive(false);
        }
        GetComponent<Collider>().enabled = false;
    }
}