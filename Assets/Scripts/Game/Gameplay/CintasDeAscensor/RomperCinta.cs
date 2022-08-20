using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperCinta : InteractiveObjectFather
{
    [SerializeField] private GameObject cintaNoRota, cintaRota;
    protected override void ActionEventCustom()
    {
        cintaNoRota.SetActive(false);
        cintaRota.SetActive(true);
    }
}
