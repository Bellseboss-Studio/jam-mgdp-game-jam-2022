using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerExtended))]
    public class RayCastPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject camera;
        private InteractiveObject objetoInteractuable;
        private InteractiveObject objetoInteractuableACambiarShader;

        private void Start()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;
            player.OnKeyOptionPress += OnKeyOptionPress;
        }

        private void OnKeyOptionPress(int keyPress)
        {
            objetoInteractuable?.SelectedOption(keyPress);
        }

        private void OnClickFromPlayer()
        {
        
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log($"Did Hit is, {hit.collider.gameObject.name}");
                if (objetoInteractuable)
                {
                    objetoInteractuable.OnMouseDown();
                }
                else
                {
                    var interactiveObject = (hit.collider.gameObject.GetComponent<InteractiveObject>());
                    if (interactiveObject)
                    {
                        objetoInteractuable = interactiveObject;
                        objetoInteractuable.OnMouseDown();
                        objetoInteractuable.OnInteractionFinished += () =>
                        {
                            objetoInteractuable = null;
                        };
                    }
                }
            }
            else
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
        }

        private void Update()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log($"Did Hit is, {hit.collider.gameObject.name}");
                if (hit.collider.gameObject.TryGetComponent<InteractiveObject>(out objetoInteractuableACambiarShader))
                {
                    objetoInteractuableACambiarShader.EnableShader();
                }
            }
            else
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
        }
    }
}