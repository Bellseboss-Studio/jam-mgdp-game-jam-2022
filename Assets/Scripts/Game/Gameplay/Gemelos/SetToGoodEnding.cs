using UnityEngine;

internal class SetToGoodEnding : MonoBehaviour
{
    [SerializeField] private InteractiveObject gemeloGoodEnding, gemeloBadEnding;
    [SerializeField] private GameObject[] objectsToActivate, objectsToDisable;
    [SerializeField] private Dialog dialog;
    public void Change()
    {
        gemeloGoodEnding.SetDialogo(dialog);
        gemeloGoodEnding.gameObject.SetActive(true);
        gemeloBadEnding.gameObject.SetActive(false);
        gemeloGoodEnding.GetComponent<Animator>().SetTrigger("idleInWall");
        foreach (var objectToActivate in objectsToActivate)
        {
            objectToActivate.SetActive(true);
        }
        foreach (var objectToDisable in objectsToDisable)
        {
            objectToDisable.SetActive(false);
        }
    }
}