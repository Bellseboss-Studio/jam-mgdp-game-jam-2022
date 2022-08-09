using UnityEngine;

namespace SystemOfExtras
{
    [RequireComponent(typeof(ItemsInventory),typeof(IngredientsInventory))]
    public class InstallerAngelScene : MonoBehaviour
    {
        [SerializeField] private ItemsInventory itemsInventory;
        [SerializeField] private IngredientsInventory ingredientsInventory;
        private void Awake()
        {
            
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            ServiceLocator.Instance.RegisterService<IIngredientsInventory>(ingredientsInventory);
            ServiceLocator.Instance.RegisterService<IItemsInventory>(itemsInventory);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}