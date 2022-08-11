using System;
using UnityEngine;

namespace SystemOfExtras
{
    public class Ingredient : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] private string id;
        [SerializeField] private GameObject model;

        public string Id => id;

        public void OnAction()
        {
            ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(id);
        }
    }
}