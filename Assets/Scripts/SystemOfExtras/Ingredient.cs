using System;
using UnityEngine;

namespace SystemOfExtras
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private GameObject model;

        public string Id => id;
        
    }
}