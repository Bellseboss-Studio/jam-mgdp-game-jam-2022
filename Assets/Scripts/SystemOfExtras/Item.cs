using UnityEngine;

namespace SystemOfExtras
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string itemName;
        public string ItemName => itemName;
        [SerializeField] private string description;
        public string Description => description;
    }
}