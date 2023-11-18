using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouse : MonoBehaviour
{
    private void OnEnable()
    {
        //Cursor.lockState = CursorLockMode.None;
        //enable the cursor
        Cursor.visible = true;
        //unlock mouse
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //disable the cursor
        Cursor.visible = false;
        //lock mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        //unlock
        Cursor.lockState = CursorLockMode.None;
        //enable the cursor
        Cursor.visible = true;
    }
}
