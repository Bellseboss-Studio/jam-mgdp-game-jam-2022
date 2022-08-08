using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private DialogsConfiguration config;
    [SerializeField] private TextMeshProUGUI text;
    private DialogsFactory _factory;
    private Dialog _dialog;

    private void Start()
    {
        _factory = new DialogsFactory(Instantiate(config));
    }

    public void OpenDialog()
    {
        anim.SetBool("open", true);
    }

    public void NextDialog()
    {
        if (_dialog.HasNextDialog)
        {
            
        }
        else
        {
            anim.SetBool("open", false);   
        }
    }

    public void OpenDialog(string idDialog)
    {
        _dialog = _factory.Create(idDialog);
        text.text = _dialog.DialogText;
        OpenDialog();
    }

    public void SelectOption(int keyPress)
    {
        OpenDialog(_dialog.GetNextDialog(keyPress));
    }
}
