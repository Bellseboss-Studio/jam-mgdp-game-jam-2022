using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarCajas : InteractiveObjectFather
{
    [SerializeField] private CajasDelAscensor cajas;
    protected override void ActionEventCustom()
    {
        cajas.ApllyAction();
    }
}
