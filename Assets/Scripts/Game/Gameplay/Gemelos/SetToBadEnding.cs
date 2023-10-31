using UnityEngine;

internal class SetToBadEnding: MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    public void Change()
    {
        trigger.SetActive(true);
    }
}