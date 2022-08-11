using System;
using System.Collections;
using Game.VisorDeDialogosSystem;
using SystemOfExtras;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private bool hasEnableShader;
    private Renderer _renderer;
    [SerializeField] private Dialog idDialog;
    public Action OnInteractionFinished;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnMouseDown()
    {
        /*Debug.Log("Click en el objeto");*/
        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(idDialog.Id);
        ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogAction(() =>
        {
            if (gameObject.TryGetComponent<IInteractiveObject>(out var interactiveObject))
            {
                InteractionFinished();
                interactiveObject.OnAction();
                ServiceLocator.Instance.GetService<IDialogSystem>().CloseDialog();
            }
        });
    }

    private void InteractionFinished()
    {
        OnInteractionFinished?.Invoke();
    }
    
    public void OnNextDialog()
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().NextDialog();
    }

    public void SelectedOption(int keyPress)
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().SelectOption(keyPress);
    }

    //Logic of Shaders
    public void EnableShader()
    {
        hasEnableShader = true;
        _renderer.material.SetFloat("_Fresnel",1);
        StartCoroutine(DisableShader());

    }

    private void LateUpdate()
    {
        hasEnableShader = false;
    }

    private IEnumerator DisableShader()
    {
        yield return new WaitForSeconds(.5f);
        if (!hasEnableShader)
        {
            _renderer.material.SetFloat("_Fresnel",0);
        }
    }
}