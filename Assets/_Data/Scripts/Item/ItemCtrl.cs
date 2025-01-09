using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": Load Item Despawn", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected virtual void LoadItemInventory()
    {
        if(this.itemInventory != null) return;
        ItemCode itemCode = ItemCodeParse.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.itemInventory.itemCount = 1;
        Debug.Log(transform.name + ": Load Item Inventory", gameObject);
    }
}
