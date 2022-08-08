using System;
using Game.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SystemOfExtras
{
    public class ItemsInventory : MonoBehaviour , IItemsInventory
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject panelItems;
        [SerializeField] private ItemImage ItemTemplate;

        private void Awake()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;    
        }

        private void OnClickFromPlayer()
        {
            var item = RayCastHelper.CompareItem(mainCamera);
            if (item) ServiceLocator.Instance.GetService<IItemsInventory>().AddItem(item);
        }

        public void AddItem(Item item)
        {
            var itemImage = Instantiate(ItemTemplate, panelItems.transform);
            itemImage.Configure(item.Sprite, item.Description);
        }
    }
}