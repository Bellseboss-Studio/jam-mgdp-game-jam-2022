using UnityEngine;

namespace SystemOfExtras
{
    public class Item : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] private string itemName;
        public string ItemName => itemName;
        [SerializeField] private string description;
        public string Description => description;
        public void OnAction()
        {
            ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(this);
        }
    }
}