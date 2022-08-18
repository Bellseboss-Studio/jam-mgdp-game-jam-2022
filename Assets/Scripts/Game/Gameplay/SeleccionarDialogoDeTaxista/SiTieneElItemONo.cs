using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class SiTieneElItemONo : MonoBehaviour
{
    [SerializeField] private InteractiveObject interactive;
    [SerializeField] private Dialog queSi, queNo;
    [SerializeField] private string idForItem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactive.SetDialogo(ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(idForItem)
                ? queSi
                : queNo);
        }
    }
}
