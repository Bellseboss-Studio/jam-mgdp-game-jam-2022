using System;
using System.Collections;
using Game.VisorDeDialogosSystem;
using UnityEngine;

public class interactiveObject : MonoBehaviour
{
    [SerializeField] private DialogSystem dialog;
    private bool hasEnableShader;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnMouseDown()
    {
        dialog.OpenDialog("01");
    }

    public void OnNextDialog()
    {
        dialog.NextDialog();
    }

    public void SelectedOption(int keyPress)
    {
        dialog.SelectOption(keyPress);
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