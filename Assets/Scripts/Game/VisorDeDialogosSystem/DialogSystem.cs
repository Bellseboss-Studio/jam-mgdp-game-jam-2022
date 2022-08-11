using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.VisorDeDialogosSystem
{
    public class DialogSystem : MonoBehaviour, IDialogSystem
    {
        [SerializeField] private Animator anim;
        [SerializeField] private DialogsConfiguration config;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float secondsDelay;
        [SerializeField] private StatesOfDialogs _statesOfDialogs;
        public StatesOfDialogs StatesOfDialogs => _statesOfDialogs;
        private DialogsFactory _factory;
        private Dialog _dialog;
        private IEnumerator fullTextInTextBox;
        private bool _isInUpdateFulledText;
        private bool _textIsFinishedOfShow;

        private void Start()
        {
            _factory = new DialogsFactory(Instantiate(config, gameObject.transform));
        }

        public void OpenDialog()
        {
            anim.SetBool("open", true);
        }

        public void NextDialog()
        {
            /*if (_dialog.HasNextDialog)
        {
            
        }
        else
        {
            anim.SetBool("open", false);   
        }*/
        }

        public void OpenDialog(string idDialog)
        {
            //Debug.Log($"is null {_dialog == null}");
            if (_textIsFinishedOfShow)
            {
                if (!_dialog.HasNextDialog)
                {
                    CloseDialog();
                    return;
                }

                if (_dialog.HasNextDialogOption)
                {
                    SelectOption(1);
                } 
                return;
            }
            if (_dialog == null)
            {
                _dialog = _factory.Create(idDialog);   
            }
            if (_isInUpdateFulledText)
            {
                StopCoroutine(fullTextInTextBox);
                text.text = _dialog.DialogText;
                _isInUpdateFulledText = false;
                _textIsFinishedOfShow = true;
                return;
            }
            fullTextInTextBox = FullTextInTextBox(_dialog.DialogText);
            StartCoroutine(fullTextInTextBox);
            OpenDialog();
        }

        private IEnumerator FullTextInTextBox(string dialogDialogText)
        {
            _textIsFinishedOfShow = false;
            _isInUpdateFulledText = true;
            for (int i = 0; i < dialogDialogText.Length; i++)
            {
                yield return new WaitForSeconds(secondsDelay);
                text.text = dialogDialogText.Substring(0, i + 1);
            }
            _isInUpdateFulledText = false;
            _textIsFinishedOfShow = true;
            _statesOfDialogs = _dialog.HasNextDialog ? StatesOfDialogs.HAS_NEXT : StatesOfDialogs.END;
        }

        public void SelectOption(int keyPress)
        {
            if (!_dialog.HasNextDialog) return;
            _textIsFinishedOfShow = false;
            _isInUpdateFulledText = false;
            var nextDialog = _dialog.GetNextDialog(keyPress);
            _dialog = null;
            OpenDialog(nextDialog);
        }

        public StatesOfDialogs GetState()
        {
            return _statesOfDialogs;
        }

        public void CloseDialog()
        {
            _dialog = null;
            _textIsFinishedOfShow = false;
            _isInUpdateFulledText = false;
            anim.SetBool("open", false);
        }
    }
}