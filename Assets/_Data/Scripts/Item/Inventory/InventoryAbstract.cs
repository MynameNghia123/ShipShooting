using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : SaiMonoBehavior
{
    [Header("Inventory Abstract")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory { get => inventory; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInParent<Inventory>();
        Debug.Log(transform.name + ":Load Inventory", gameObject);
    }
}
