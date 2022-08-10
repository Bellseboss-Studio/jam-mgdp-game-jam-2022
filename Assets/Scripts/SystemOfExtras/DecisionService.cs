using System;
using Game.Player;
using Game.VisorDeDialogosSystem;

namespace SystemOfExtras
{
    public class DecisionService : IDecisionService
    {
        private readonly PlayerExtended _playerExtended;
        private bool _takingDecision;

        public DecisionService(PlayerExtended playerExtended)
        {
            _playerExtended = playerExtended;
            _playerExtended.OnKeyOptionPress += OnKeyOptionPress;
        }

        private void OnKeyOptionPress(int value)
        {
            if (!_takingDecision) return;
            ServiceLocator.Instance.GetService<IDialogSystem>().SelectOption(value);
        }


        public void StartDecision(Item item)
        {
            _takingDecision = true;
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog("ItemTest");
            if (ServiceLocator.Instance.GetService<IDialogSystem>().GetState() == StatesOfDialogs.END)
                ServiceLocator.Instance.GetService<IDialogSystem>().CloseDialog();
        }
    }
}