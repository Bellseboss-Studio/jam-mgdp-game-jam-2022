using System;
using System.Collections.Generic;
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
        [SerializeField] private List<SpaceToItem> spacesToItems;
        [SerializeField] private GameObject backpack, itemUI;
        [SerializeField] private TMP_Text nameText, descriptionText;
        private bool _backpackShowed = true;
        private bool _movingBackpack;
        [SerializeField] private float moveInY, animationDuration;
        private Item itemToTake;

        private void Awake()
        {
            _player.OnItemPressed += OnClickFromPlayer;
        }

        private void ConfigurePlayer(Transform playerCapsule)
        {
            var rotation = playerCapsule.rotation;
            playerCapsule.rotation = new Quaternion(0,0,0,0);
            backpack.transform.SetParent(_playerReferences.PlayerCameraRoot);
            backpack.transform.position = _playerReferences.ItemsContainerPosition.position;
            Destroy(_playerReferences.ItemsContainerPosition.gameObject);
            playerCapsule.rotation = rotation;
        }

        private void OnClickFromPlayer()
        {
            var item = RayCastHelper.CompareItem(_mainCamera);
            if (item) ShowItemUI(item);/*
            if (item) SaveItem(item);*/
        }

        private void ShowItemUI(Item item)
        {
            ServiceLocator.Instance.GetService<IDecisionService>().StartDecision(item);
            /*ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog();
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog("ItemTest");
            */
            itemToTake = item;
            Debug.Log($"item name: {item.ItemName}, item description: {item.Description}");
        }

        public void SaveItem(Item item)
        {
            foreach (var spaceToItem in spacesToItems)
            {
                if (spaceToItem.CurrentItem) continue;
                spaceToItem.CurrentItem = item;
                item.transform.position = spaceToItem.transform.position;
                item.transform.SetParent(backpack.transform);
                item.transform.rotation = backpack.transform.rotation;
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

        public void Configure(PlayerExtended playerExtended, PlayerReferences playerReferences, GameObject mainCamera, Transform playerCapsule)
        {
            _player = playerExtended;
            _playerReferences = playerReferences;
            _mainCamera = mainCamera;
            ConfigurePlayer(playerCapsule);
        }
    }
}