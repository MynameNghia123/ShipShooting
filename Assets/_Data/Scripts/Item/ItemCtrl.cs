using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }
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
        this.itemInventory = new ItemInventory(itemInventory.itemProfile, itemInventory.itemCount, itemInventory.maxStack, itemInventory.upgradeLevel);

    }
    protected virtual void LoadItemInventory()
    {
        if(this.itemInventory != null) return;
        ItemCode itemCode = ItemCodeParse.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();
        Debug.Log(transform.name + ": Load Item Inventory", gameObject);
    }
    protected virtual void ResetItem()
    {
        ItemInventory itemInventory = new ItemInventory(this.itemInventory.itemProfile, 1, this.itemInventory.maxStack, 0); ;
        this.itemInventory = itemInventory;
    }
}
