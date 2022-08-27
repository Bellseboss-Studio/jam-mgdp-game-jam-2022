using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlCentroComercialBicicleta : InteractiveObjectFather
{
    [SerializeField] private int minutos;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<ITimeService>().AddMinutes(minutos);
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
}