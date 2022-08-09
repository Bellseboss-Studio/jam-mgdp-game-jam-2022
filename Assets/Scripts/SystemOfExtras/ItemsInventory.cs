using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace SystemOfExtras
{
    public class ItemsInventory : MonoBehaviour , IItemsInventory
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private List<SpaceToItem> spacesToItems;
        [SerializeField] private GameObject backpack;
        private bool _backpackShowed = true;
        private bool _movingBackpack;
        [SerializeField] private float moveInY, animationDuration;

        private void Awake()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;    
        }

        private void OnClickFromPlayer()
        {
            var item = RayCastHelper.CompareItem(mainCamera);
            if (item) ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(item);
        }


        public void SaveItem(Item item)
        {
            foreach (var spaceToItem in spacesToItems)
            {
                if (!spaceToItem.CurrentItem) continue;
                spaceToItem.CurrentItem = item;
                item.transform.position = spaceToItem.transform.position;
                return;
            }
            //Si no hay espacio para el item
            NotSpaceToItem();
        }

        private void NotSpaceToItem()
        {
            Debug.Log("No hay espacio para el item");
        }

        private void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                ShowAndHideBackpack();
            }
        }

        private void ShowAndHideBackpack()
        {
            if (_movingBackpack) return;
            if (_backpackShowed)
            {
                _movingBackpack = true;
                var sequence = DOTween.Sequence();
                var localPosition = backpack.transform.localPosition;
                sequence.Insert(0,
                    backpack.transform.DOLocalMove(
                        new Vector3(localPosition.x, localPosition.y - moveInY, localPosition.z), animationDuration).SetEase(Ease.InBack));
                sequence.onComplete = () =>
                {
                    _movingBackpack = false;
                };
            }
            else
            {
                _movingBackpack = true;
                var sequence = DOTween.Sequence();
                var localPosition = backpack.transform.localPosition;
                sequence.Insert(0,
                    backpack.transform.DOLocalMove(
                        new Vector3(localPosition.x, localPosition.y + moveInY, localPosition.z), animationDuration).SetEase(Ease.OutBack));
                sequence.onComplete = () =>
                {
                    _movingBackpack = false;
                };
            }
            _backpackShowed = !_backpackShowed;
        }
    }
}