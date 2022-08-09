using UnityEngine;

namespace SystemOfExtras
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string description;
        public string Description => description;
        [SerializeField] private string name1;
        public string Name1 => name1;
        [SerializeField] private float cost;
        public float Cost => cost;
    }
}