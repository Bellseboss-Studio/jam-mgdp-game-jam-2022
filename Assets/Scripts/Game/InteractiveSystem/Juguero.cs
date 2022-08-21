using SystemOfExtras;
using UnityEngine;

public class Juguero : InteractiveObject
{
    [SerializeField] private Dialog nocheEsMalo, nocheEsBuenoConBillete, nocheEsBuenoSinBillete;
    [SerializeField] private Item billete;
    public override void OnMouseDown()
    {
        if (ServiceLocator.Instance.GetService<ITimeService>().IsNigth())
        {
            if (ServiceLocator.Instance.GetService<IMoralService>().GetIsBad())
            {
                idDialog = nocheEsMalo;
            }
            else
            {
                if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(billete.Id))
                {
                    idDialog = nocheEsBuenoConBillete;
                }
                else
                {
                    idDialog = nocheEsBuenoSinBillete;
                }
            }
        }
        base.OnMouseDown();
    }
}