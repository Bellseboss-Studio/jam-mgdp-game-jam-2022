using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SystemOfExtras
{
    public class IngredientImage : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private RectTransform tacha;
        [SerializeField] private TMP_Text text;
        public string ID => id;

        public void CrossOut()
        {
            tacha.DOSizeDelta(new Vector2(.22f, .03f), 1.5f);
        }
        private void Update()
        {
        }

        public void Configure(string ingredient)
        {
            id = ingredient;
            text.text = ingredient;
        }
    }
}