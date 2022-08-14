using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

public class TomarDestornilladorActionOtra : InteractiveObjectFather
{
    [SerializeField] private InteractiveObject itemDeLlave;
    [SerializeField] private Dialog cambioDeDialogoDeLlave;
    protected override void ActionEventCustom()
    {
        Debug.Log("Cambio el dialogo");
        itemDeLlave.SetDialogo(cambioDeDialogoDeLlave);
    }
}
