using System;
using Game.VisorDeDialogosSystem;

namespace SystemOfExtras
{
    public interface IDialogSystem
    {
        public void OpenDialog(string idDialog);
        public void SelectOption(int keyPress);
        void OnDialogAction(Action<string> action);
        void OnDialogFinish(Action action);
        void SetDialogToNotSpaceToItems();
    }
}