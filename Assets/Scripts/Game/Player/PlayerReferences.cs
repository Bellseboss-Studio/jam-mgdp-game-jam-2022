using UnityEngine;

namespace Game.Player
{
    public class PlayerReferences : MonoBehaviour
    {
        [SerializeField] private Transform /*hojaPosition, itemsContainerPosition,*/ playerCameraRoot;

        /*public Transform HojaPosition => hojaPosition;

        public Transform ItemsContainerPosition => itemsContainerPosition;*/

        public Transform PlayerCameraRoot => playerCameraRoot;
    }
}