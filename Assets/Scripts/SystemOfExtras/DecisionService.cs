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
            //_playerExtended.OnKeyOptionPress += OnKeyOptionPress;
        }

        private void OnKeyOptionPress(int value)
        {
            if (!_takingDecision) return;
        }


        public void StartDecision(Item item)
        {
            _takingDecision = true;
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog("ItemTest");
        }
    }
}