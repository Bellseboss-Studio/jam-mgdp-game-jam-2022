using SystemOfExtras;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxistaGoMall : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    [SerializeField] private int minutos;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<ITimeService>().AddMinutes(minutos);
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
        ServiceLocator.Instance.GetService<ILoadScream>().Close(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        });
    }
}