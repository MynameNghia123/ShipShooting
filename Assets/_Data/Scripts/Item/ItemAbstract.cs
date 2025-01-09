using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : SaiMonoBehavior
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = GetComponentInParent<ItemCtrl>();
        Debug.Log(transform.name + ": Load Item Ctrl", gameObject);
    }
}
