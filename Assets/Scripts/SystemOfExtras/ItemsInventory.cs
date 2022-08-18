using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace SystemOfExtras
{
    public class ItemsInventory : MonoBehaviour , IItemsInventory
    {
        private PlayerExtended _player;
        private PlayerReferences _playerReferences;
        private GameObject _mainCamera;
        private List<InteractiveObject> _items;
        [SerializeField] private List<SpaceToItem> spacesToItems;
        [SerializeField] private Dialog dialogForNotItemSpace;
        [SerializeField] private GameObject backpack;
        private bool _backpackShowed = true;
        private bool _movingBackpack;
        [SerializeField] private float moveInY, animationDuration;
        private int _itemsSaved;

        private void Awake()
        {
            _items = new List<InteractiveObject>();
            var items1 = FindObjectsOfType<Item>();
            foreach (var item in items1)
            {
                _items.Add(item.InteractiveObject);
            }
        }

        private void ConfigurePlayer(Transform playerCapsule)
        {
            var rotation = playerCapsule.rotation;
            playerCapsule.rotation = new Quaternion(0,0,0,0);
            backpack.transform.SetParent(_playerReferences.PlayerCameraRoot);
            backpack.transform.position = _playerReferences.ItemsContainerPosition.position;
            Destroy(_playerReferences.ItemsContainerPosition.gameObject);
            playerCapsule.rotation = rotation;
            _player.OnItemPressed += OnClickFromPlayer;
        }

        private void OnClickFromPlayer()
        {
            var item = RayCastHelper.CompareItem(_mainCamera);
            /*if (item) ShowItemUI(item);
            if (item) SaveItem(item);*/
        }

        private void ShowItemUI(Item item)
        {
            ServiceLocator.Instance.GetService<IDecisionService>().StartDecision(item);
            /*ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog();
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog("ItemTest");
            */
        }

        public void SaveItem(Item item)
        {
            _itemsSaved = 0;
            var savedItem = false;
            foreach (var spaceToItem in spacesToItems)
            {
                if (spaceToItem.CurrentItem)
                {
                    _itemsSaved++;
                    continue;
                }

                if (savedItem) continue;
                savedItem = true;
                spaceToItem.CurrentItem = item;
                item.transform.position = spaceToItem.transform.position;
                item.transform.SetParent(backpack.transform);
                item.transform.rotation = backpack.transform.rotation;
                item.PutInTheBackpack();
            }

            if (_itemsSaved>=2)
            {
                foreach (var item1 in _items)
                {
                    item1.SetDialogo(dialogForNotItemSpace);
                }
            }
            //Si no hay espacio para el item
        }

        bool SearchItemForId(string id)
        {
            foreach (var spaceToItem in spacesToItems)
            {
                if (spaceToItem.CurrentItem!= null & spaceToItem.CurrentItem.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void ThrowItem(int itemPosition)
        {
            if (spacesToItems[itemPosition].CurrentItem == null)
            {
                /*ServiceLocator.Instance.GetService<IDialogSystem>(). OpenDialog(dialogToNotItemToThrow.Id);*/
            }
            else
            {
                Debug.Log($"tirando item{itemPosition}");
                _items.Remove(spacesToItems[itemPosition].CurrentItem.InteractiveObject);
                Destroy(spacesToItems[itemPosition].CurrentItem.gameObject);
                RestoreItemsDialog();
            }
        }

        private void RestoreItemsDialog()
        {
            foreach (var item in _items)
            {
                item.RestoreDialog();
            }
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

        public void Configure(PlayerExtended playerExtended, PlayerReferences playerReferences, GameObject mainCamera, Transform playerCapsule)
        {
            _player = playerExtended;
            _playerReferences = playerReferences;
            _mainCamera = mainCamera;
            ConfigurePlayer(playerCapsule);
        }
    }
}