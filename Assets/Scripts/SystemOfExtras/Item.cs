using UnityEngine;

namespace SystemOfExtras
{
    public class Item : InteractiveObjectFather
    {
        [SerializeField] private string itemName;
        public string ItemName => itemName;
        [SerializeField] private string description;
        public string Description => description;
        protected override void ActionEventCustom()
        {
            ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(this);
        }

        public void SetDialogo(Dialog cambioDeDialogoDeLlave)
        {
            dialogToAction = cambioDeDialogoDeLlave;
        }
    }
}