using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class InitializationInScene2 : MonoBehaviour
{
    [SerializeField] private GameObject pointToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
            {
                var transformPlayer = ServiceLocator.Instance.GetService<IItemsInventory>().GetTransformPlayer();
                transformPlayer.position = pointToSpawn.transform.position;
                transformPlayer.rotation = pointToSpawn.transform.rotation;
            });
        });
    }
}
