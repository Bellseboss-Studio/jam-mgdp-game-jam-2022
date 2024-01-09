using System;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerExtended))]
    public class RayCastPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject camera;
        [SerializeField] private float distanceRayCast = 3f;
        private InteractiveObject objetoInteractuable;
        private InteractiveObject objetoInteractuableACambiarShader;
        private Reloj _reloj;

        private void Start()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;
            player.OnKeyOptionPress += OnKeyOptionPress;
        }

        private void OnKeyOptionPress(int keyPress)
        {
            //Debug.Log($"Key press {keyPress} and {objetoInteractuable == null}");
            objetoInteractuable?.SelectedOption(keyPress);
        }

        private void OnClickFromPlayer()
        {
            RaycastHit[] hit;
            //shot raycast to all objects
            hit = Physics.RaycastAll(camera.transform.position, camera.transform.TransformDirection(Vector3.forward));
            Debug.Log($"Hit length {hit.Length}");
            foreach (var raycastHit in hit)
            {
                Debug.Log($"Hit {raycastHit.collider.gameObject.name}");
                if (raycastHit.collider.gameObject.TryGetComponent<InteractiveObject>(out var interactiveObject))
                {
                    objetoInteractuable = interactiveObject;
                    objetoInteractuable.OnInteractionFinished += () =>
                    {
                        objetoInteractuable = null; 
                    };
                    break;
                }
                if (raycastHit.collider.gameObject.TryGetComponent<Reloj>(out var reloj))
                {
                    _reloj = reloj;
                    _reloj.OnInteractionFinished += idDialog =>
                    {
                        _reloj = null; 
                    };
                    break;
                }
            }
            objetoInteractuable?.OnMouseDown();
            _reloj?.OnMouseDown();
        }

        private void Update()
        {
            RaycastHit[] hit;
            //shot raycast to all objects
            hit = Physics.RaycastAll(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), distanceRayCast);
            Debug.Log($"Hit length {hit.Length}");
            Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * distanceRayCast, Color.white);
            foreach (var raycastHit in hit)
            {
                Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * raycastHit.distance, Color.yellow);
                //Debug.Log($"Did Hit is, {hit.collider.gameObject.name}");
                if (raycastHit.collider.gameObject.TryGetComponent(out objetoInteractuableACambiarShader))
                {
                    objetoInteractuableACambiarShader.EnableShader();
                    break;
                }
            }
        }
    }
}