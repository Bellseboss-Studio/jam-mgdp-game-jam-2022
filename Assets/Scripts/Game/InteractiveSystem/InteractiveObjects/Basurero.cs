using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

namespace Game.InteractiveSystem.InteractiveObjects
{
    public class Basurero : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] private List<Dialog> dialogsToAction;
        public bool OnAction(string idDialog)
        {
            var cont = 0;
            foreach (var dialog in dialogsToAction)
            {
                Debug.Log($"Saw {dialog.Id} == {idDialog} : {dialog.Id == idDialog}");
                if (dialog.Id == idDialog)
                {
                    ActionEventCustom(cont);
                    return true;
                }
                cont++;
            }
            return false;
        }

        private void ActionEventCustom(int cont)
        {
            ServiceLocator.Instance.GetService<IItemsInventory>().ThrowItem(cont);
        }
    }
}