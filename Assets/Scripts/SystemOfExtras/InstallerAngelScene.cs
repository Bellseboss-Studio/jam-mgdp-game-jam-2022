using Game.Player;
using Game.VisorDeDialogosSystem;
using UnityEngine;

namespace SystemOfExtras
{
    [RequireComponent(typeof(ItemsInventory),typeof(IngredientsInventory), typeof(DialogSystem))]
    public class InstallerAngelScene : MonoBehaviour
    {
        [SerializeField] private ItemsInventory itemsInventory;
        [SerializeField] private IngredientsInventory ingredientsInventory;
        [SerializeField] private DialogSystem dialogSystem;
        [SerializeField] private PlayerExtended player;
        [SerializeField] private Transform playerCapsule;
        [SerializeField] private PlayerReferences playerReferences;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private LoadScreamService loadScream;
        private void Awake()
        {
            if (itemsInventory) itemsInventory.Configure(player, playerReferences, mainCamera, playerCapsule);
            if (ingredientsInventory) ingredientsInventory.Configure(player, playerReferences, mainCamera, playerCapsule);
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            ServiceLocator.Instance.RegisterService<IIngredientsInventory>(ingredientsInventory);
            ServiceLocator.Instance.RegisterService<IItemsInventory>(itemsInventory);
            ServiceLocator.Instance.RegisterService<IDialogSystem>(dialogSystem);
            var decisionService = new DecisionService(player);
            ServiceLocator.Instance.RegisterService<IDecisionService>(decisionService);
            ServiceLocator.Instance.RegisterService<ILoadScream>(loadScream);
            DontDestroyOnLoad(gameObject);
        }
    }
}