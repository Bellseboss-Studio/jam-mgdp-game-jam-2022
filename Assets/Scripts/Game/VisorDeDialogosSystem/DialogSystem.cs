using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private DialogsConfiguration config;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float secondsDelay;
    [SerializeField] private StatesOfDialogs _statesOfDialogs;
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
        //if(_statesOfDialogs)
        _statesOfDialogs = StatesOfDialogs.START;
        _dialog = _factory.Create(idDialog);
        StartCoroutine(FullTextInTextBox(_dialog.DialogText));
        OpenDialog();
    }

    private IEnumerator FullTextInTextBox(string dialogDialogText)
    {
        _statesOfDialogs = StatesOfDialogs.UPDATE;
        for (int i = 0; i < dialogDialogText.Length; i++)
        {
            yield return new WaitForSeconds(secondsDelay);
            text.text = dialogDialogText.Substring(0, i + 1);
        }
        _statesOfDialogs = StatesOfDialogs.END;
    }

    public void SelectOption(int keyPress)
    {
        OpenDialog(_dialog.GetNextDialog(keyPress));
    }
}

public enum StatesOfDialogs
{
    START,
    UPDATE,
    END,
}