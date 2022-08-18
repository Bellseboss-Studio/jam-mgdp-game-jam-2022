using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnviarElPlayerDeEscena1Escena2 : InteractiveObjectFather
{
    [SerializeField] private int sceneToLoad;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<ILoadScream>().Open(() =>
        {
            SceneManager.LoadScene(sceneToLoad);
        });
    }
}
