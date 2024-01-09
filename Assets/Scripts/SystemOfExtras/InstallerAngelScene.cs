using System.Collections.Generic;
using Game.Player;
using Game.VisorDeDialogosSystem;
using GameAudio;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SystemOfExtras
{
    [RequireComponent(typeof(ItemsInventory),typeof(IngredientsInventory), typeof(DialogSystem))]
    [RequireComponent(typeof(TimeService))]
    public class InstallerAngelScene : MonoBehaviour, IMediatorPlayer
    {
        [SerializeField] private ItemsInventory itemsInventory;
        [SerializeField] private TimeService timeService;
        [SerializeField] private IngredientsInventory ingredientsInventory;
        [SerializeField] private DialogSystem dialogSystem;
        [SerializeField] private PlayerExtended player;
        [SerializeField] private Transform playerCapsule;
        [SerializeField] private PlayerReferences playerReferences;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private LoadScreamService loadScream;
        [SerializeField] private FirstPersonControllerAngel firstPersonControllerAngel;
        [SerializeField] private MissionControlUIView missionControlUIView;
        [SerializeField] private GameObject playerAnimation;
        [SerializeField] private PlayerInput scriptToDisable;
        [SerializeField] private MonoBehaviour scriptToMovePlayer;
        private void Awake()
        {
            if (FindObjectsOfType<InstallerAngelScene>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            if (itemsInventory) itemsInventory.Configure(player, playerReferences, mainCamera, playerCapsule, this);
            if (ingredientsInventory) ingredientsInventory.Configure(player, playerReferences, mainCamera, playerCapsule, this);
            if(firstPersonControllerAngel) firstPersonControllerAngel.ConfigurePlayer(this);
            ServiceLocator.Instance.RegisterService<IIngredientsInventory>(ingredientsInventory);
            ServiceLocator.Instance.RegisterService<IItemsInventory>(itemsInventory);
            ServiceLocator.Instance.RegisterService<IDialogSystem>(dialogSystem);
            var decisionService = new DecisionService(player);
            ServiceLocator.Instance.RegisterService<IDecisionService>(decisionService);
            var moralService = new MoralService();
            ServiceLocator.Instance.RegisterService<IMoralService>(moralService);
            //ServiceLocator.Instance.RegisterService<ILoadScream>(loadScream);
            ServiceLocator.Instance.RegisterService<ITimeService>(timeService);
            ServiceLocator.Instance.RegisterService<IMediatorPlayer>(this);
            DontDestroyOnLoad(gameObject);
        }
        
        public void HidePlayer()
        {
            Debug.Log("Hide player");
            playerAnimation.SetActive(false);
            scriptToDisable.enabled = false;
            dialogSystem.CloseDialog();
        }

        public void LockPlayer(bool lockPlayer)
        {
            scriptToMovePlayer.enabled = !lockPlayer;
        }

        public IInputBellseboss GetInput()
        {
            return firstPersonControllerAngel;
        }

        public Vector3 GetPlayerPosition()
        {
            return playerCapsule.position;
        }

        public void SetListOfMission(List<MissionDetail> ingredientsDetails)
        {
            StatesOfStatesMissions missions = new StatesOfStatesMissions(ingredientsDetails);
            ServiceLocator.Instance.RegisterService<IStatesMissions>(missions);
            missionControlUIView.Config();
        }
    }
}