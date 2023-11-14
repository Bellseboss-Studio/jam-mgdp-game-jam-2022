
using UnityEngine;

public class TurnOffTv : InteractiveObjectFather
{
    [SerializeField] private GameObject[] screem;
    protected override void ActionEventCustom()
    {
        foreach (var item in screem)
        {
            item.SetActive(false);
        }
    }
}