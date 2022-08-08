using UnityEngine;

namespace SystemOfExtras
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private string description;

        public Sprite Sprite => sprite;
        public string Description => description;
    }
}