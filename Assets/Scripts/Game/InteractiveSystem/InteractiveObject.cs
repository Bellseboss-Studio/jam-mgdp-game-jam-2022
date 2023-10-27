using System;
using System.Collections;
using GameAudio;
using SystemOfExtras;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private bool hasEnableShader;
    [SerializeField] private Renderer _renderer;
    [SerializeField] protected Dialog idDialog;
    public Action OnInteractionFinished;
    protected Dialog OriginalDialog;
    protected bool CambioDialogo;

    private void Start()
    {
        if(_renderer == null)
        {
            if (TryGetComponent<Renderer>(out var render))
            {
                _renderer = render;
            }
        }
        OriginalDialog = idDialog;
        StartCustom();
    }

    protected virtual void StartCustom()
    {
        
    }

    public virtual void OnMouseDown()
    {
        /*Debug.Log("Click en el objeto");*/
        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(idDialog.Id, isDialog =>
            {
                foreach (var component in GetComponents<IInteractiveObject>())
                {
                    component.OnAction(isDialog);
                }

                ServiceLocator.Instance.GetService<InteractablesSounds>().PlaySound(isDialog);
            },
            idDialog =>
            {
                InteractionFinished(idDialog);
            });
    }

    private void InteractionFinished(string idDialog)
    {
        Debug.Log($"Finish interaction: " + idDialog);
        OnInteractionFinished?.Invoke();
    }

    public void SelectedOption(int keyPress)
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().SelectOption(keyPress);
    }

    //Logic of Shaders
    public void EnableShader()
    {
        hasEnableShader = true;
        try
        {
            _renderer?.material.SetFloat("_Fresnel", 1);
        }catch(Exception e)
        {
            Debug.LogWarning(e);
        }
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
            try
            {
                _renderer?.material.SetFloat("_Fresnel",0);
            }catch(Exception e)
            {
                Debug.LogWarning(e);
            }
        }
    }

    public void SetDialogo(Dialog cambioDeDialogoDeLlave)
    {
        idDialog = cambioDeDialogoDeLlave;
        CambioDialogo = true;
    }

    public void RestoreDialog()
    {
        idDialog = OriginalDialog;
    }
}