using UnityEngine;

namespace SystemOfExtras
{
    public static class RayCastHelper
    {
        public static Ingredient CompareIngredient(GameObject mainCamera)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward),
                out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<Ingredient>(out var ingredient))
                {
                    Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("hit on item");
                    return ingredient;
                }
            }
            else
            {
                Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000,
                    Color.white);
            }
            return null;
        }

        public static Item CompareItem(GameObject mainCamera)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward),
                out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<Item>(out var item))
                {
                    Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("hit on ingredient");
                    return item;
                }
            }
            else
            {
                Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * 1000,
                    Color.white);
            }
            return null;
        }
    }
}