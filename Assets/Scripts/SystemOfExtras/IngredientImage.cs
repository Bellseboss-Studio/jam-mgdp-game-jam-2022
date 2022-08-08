using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SystemOfExtras
{
    public class IngredientImage : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text description;
        
        public void Configure(Sprite sprite, string ingredientDescription)
        {
            image.sprite = sprite;
            description.text = ingredientDescription;
        }
    }
}