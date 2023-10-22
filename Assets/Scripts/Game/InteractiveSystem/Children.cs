using System;
using SystemOfExtras;
using UnityEngine;

public class Children : InteractiveObject
{
    [SerializeField] private Dialog youCantHaveTheMoney;
    [SerializeField] private Item billete;
    [SerializeField]private float minDistanceToStop;
    private bool _runToForwardPlayer;

    public override void OnMouseDown()
    {
        if (!CambioDialogo)
        {
            idDialog = !ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForIdAndCount(billete.Id, 1) ? youCantHaveTheMoney : OriginalDialog;   
        }
        base.OnMouseDown();
    }

    public void RunToForwardPlayer()
    {
        _runToForwardPlayer = true;
    }

    private void Update()
    {
        if (_runToForwardPlayer)
        {
            //move towards the player but never move in y axis
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ServiceLocator.Instance.GetService<IMediatorPlayer>().GetPlayerPosition().x, transform.position.y, ServiceLocator.Instance.GetService<IMediatorPlayer>().GetPlayerPosition().z), 0.1f);
            //rotate to look at the player and never rotate in y axis
            transform.LookAt(new Vector3(ServiceLocator.Instance.GetService<IMediatorPlayer>().GetPlayerPosition().x, transform.position.y, ServiceLocator.Instance.GetService<IMediatorPlayer>().GetPlayerPosition().z));
            var distance = Vector3.Distance(transform.position, ServiceLocator.Instance.GetService<IMediatorPlayer>().GetPlayerPosition());
            Debug.Log(distance);
            _runToForwardPlayer = distance > minDistanceToStop;
        }
    }
}