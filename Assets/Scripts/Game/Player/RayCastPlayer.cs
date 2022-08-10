using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerExtended))]
    public class RayCastPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject camera;
        private interactiveObject objetoInteractuable;

        private void Start()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;
            player.OnNextDialog += OnNextDialog;
            player.OnKeyOptionPress += OnKeyOptionPress;
        }

        private void OnKeyOptionPress(int keyPress)
        {
            objetoInteractuable?.SelectedOption(keyPress);
        }

        private void OnNextDialog()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log($"Did Hit is, {hit.collider.gameObject.name}");
                if (hit.collider.gameObject.TryGetComponent<interactiveObject>(out var objetoInteractuable))
                {
                    objetoInteractuable.OnNextDialog();
                }
            }
            else
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        private void OnClickFromPlayer()
        {
        
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log($"Did Hit is, {hit.collider.gameObject.name}");
                if (hit.collider.gameObject.TryGetComponent<interactiveObject>(out objetoInteractuable))
                {
                    objetoInteractuable.OnMouseDown();
                }
            }
            else
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
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
                if (hit.collider.gameObject.TryGetComponent<interactiveObject>(out objetoInteractuable))
                {
                    objetoInteractuable.EnableShader();
                }
            }
            else
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}