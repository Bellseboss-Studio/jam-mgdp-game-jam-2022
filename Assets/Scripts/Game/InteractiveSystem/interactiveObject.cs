using System;
using UnityEngine;

public class interactiveObject : MonoBehaviour
{
    [SerializeField] private DialogSystem dialog;

    public void OnMouseDown()
    {
        dialog.OpenDialog("01");
    }

    public void OnNextDialog()
    {
        dialog.NextDialog();
    }

    public void SelectedOption(int keyPress)
    {
        dialog.SelectOption(keyPress);
    }
}