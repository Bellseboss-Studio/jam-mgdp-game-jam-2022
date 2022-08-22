using System;
using System.Collections;
using SystemOfExtras;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    private bool hasEnableShader;
    private Renderer _renderer = null;
    [SerializeField] protected TimeDialog idDialog;
    public Action<string> OnInteractionFinished;
    private Dialog _originalDialog;

    private void Start()
    {
        if (TryGetComponent<Renderer>(out var render))
        {
            _renderer = render;
        }
        _originalDialog = idDialog;
    }

    public void OnMouseDown()
    {
        /*Debug.Log("Click en el objeto");*/
        idDialog.ActualizeTimeDialog(ServiceLocator.Instance.GetService<ITimeService>().GetTime());
        ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(idDialog.Id);
        ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogAction( isDialog =>
        {
            foreach (var component in gameObject.GetComponents<IInteractiveObject>())
            {
                component.OnAction(isDialog);
            }
        });
        ServiceLocator.Instance.GetService<IDialogSystem>().OnDialogFinish(idDialog =>
        {
            InteractionFinished(idDialog);
        });
    }

    private void InteractionFinished(string idDialog)
    {
        /*Debug.Log($"Finish interaction");*/
        OnInteractionFinished?.Invoke(idDialog);
    }

    public void SelectedOption(int keyPress)
    {
        ServiceLocator.Instance.GetService<IDialogSystem>().SelectOption(keyPress);
    }

    //Logic of Shaders
    public void EnableShader()
    {
        hasEnableShader = true;
        _renderer?.material.SetFloat("_Fresnel",1);
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
            _renderer?.material.SetFloat("_Fresnel",0);
        }
    }
}