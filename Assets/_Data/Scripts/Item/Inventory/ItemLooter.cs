using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent (typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.Log(transform.name + ": Load Sphere Collider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        this._rigidbody.useGravity = false;
        Debug.Log(transform.name + ": Load Rigidbody", gameObject);

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();

        if (itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if(this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
       
    }
}
