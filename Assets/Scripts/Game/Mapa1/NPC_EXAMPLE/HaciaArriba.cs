using UnityEngine;

public class HaciaArriba : InteractiveObjectFather
{
    private bool canGoUp;
    void Update()
    {
        if (canGoUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, Time.deltaTime);
        }
    }
    protected override void ActionEventCustom()
    {
        Debug.Log($"{typeof(HaciaArriba)}");
        canGoUp = true;
    }
}