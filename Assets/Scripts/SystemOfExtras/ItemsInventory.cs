using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Player;
using GameAudio;
using TMPro;
using Unity.VisualScripting;
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
        [SerializeField] private GameObject pointToStart, pointToEnd;
        private bool _backpackShowed;
        private bool _movingBackpack;
        [SerializeField] private float moveInY, animationDuration;
        private int _itemsSaved;
        private Transform referenceOfPlayer;
        private IMediatorPlayer _mediator;
        private float _timeToWait = 0.5f;

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
            //backpack.transform.SetParent(_playerReferences.PlayerCameraRoot);
            //backpack.transform.position = _playerReferences.ItemsContainerPosition.position;
            //Destroy(_playerReferences.ItemsContainerPosition.gameObject);
            playerCapsule.rotation = rotation;
            _player.OnItemPressed += OnClickFromPlayer;
            ShowAndHideBackpack();
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

        public bool SearchItemForId(string id)
        {
            return SearchItemForIdAndCount(id, 1);
        }
        public bool SearchItemForIdAndCount(string id, int count)
        {
            int countItems = 0;
            foreach (var spaceToItem in spacesToItems)
            {
                if (spaceToItem.CurrentItem != null && spaceToItem.CurrentItem.Id == id)
                {
                    countItems++;
                }
            }
            return countItems >= count;
        }

        public bool HasSpace()
        {
            return _itemsSaved < 2;
        }

        public int RemoveItemById(string itemId)
        {
            return RemoveItemById(itemId, 1);
        }
        public int RemoveItemById(string itemId, int count)
        {
            int countItemsRemove = 0;
            foreach (var spaceToItem in spacesToItems)
            {
                if (spaceToItem.CurrentItem != null && spaceToItem.CurrentItem.Id == itemId && countItemsRemove < count)
                {
                    _items.Remove(spaceToItem.CurrentItem.InteractiveObject);
                    Destroy(spaceToItem.CurrentItem.gameObject);
                    countItemsRemove++;
                    RestoreItemsDialog();
                }
            }
            return countItemsRemove;
        }

        public Transform GetTransformPlayer()
        {
            return referenceOfPlayer;
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
                ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound("DiscardItem");
                _items.Remove(spacesToItems[itemPosition].CurrentItem.InteractiveObject);
                Destroy(spacesToItems[itemPosition].CurrentItem.gameObject);
                RestoreItemsDialog();
                _itemsSaved--;
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
            //Adding a bit cool down to the inventory
            if (_timeToWait > 0)
            {
                _timeToWait -= Time.deltaTime;
                return;
            }
            if (_mediator.GetInput().PressInventoryButton())
            {
                ShowAndHideBackpack();
                _timeToWait = 0.5f;
            }
        }

        private void ShowAndHideBackpack()
        {
            if (_movingBackpack) return;
            if (_backpackShowed)
            {
                _movingBackpack = true;
                var sequence = DOTween.Sequence();
                sequence.Insert(0,
                    backpack.transform.DOLocalMove(
                        pointToEnd.transform.localPosition, animationDuration).SetEase(Ease.InBack));
                sequence.onComplete = () =>
                {
                    _movingBackpack = false;
                };
            }
            else
            {
                _movingBackpack = true;
                var sequence = DOTween.Sequence();
                sequence.Insert(0,
                    backpack.transform.DOLocalMove(
                        pointToStart.transform.localPosition, animationDuration).SetEase(Ease.OutBack));
                sequence.onComplete = () =>
                {
                    _movingBackpack = false;
                };
            }
            _backpackShowed = !_backpackShowed;
        }

        public void Configure(PlayerExtended playerExtended, PlayerReferences playerReferences, GameObject mainCamera,
            Transform playerCapsule, IMediatorPlayer mediator)
        {
            _player = playerExtended;
            _playerReferences = playerReferences;
            _mainCamera = mainCamera;
            referenceOfPlayer = playerCapsule;
            ConfigurePlayer(playerCapsule);
            _mediator = mediator;
        }
    }
}