using UnityEngine;

public class HaciaAbajo : InteractiveObjectFather
{
    private bool canGoDown;
    void Update()
    {
        if (canGoDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, Time.deltaTime);
        }
    }
    protected override void ActionEventCustom()
    {
        Debug.Log($"{typeof(HaciaAbajo)}");
        canGoDown = true;
    }
}