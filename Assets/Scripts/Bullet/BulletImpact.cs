using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
        this.rb.isKinematic = true;
        Debug.Log(transform.name + ": Load Ridigbody", gameObject);
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.SenderDamage.Send(other.transform);   
    }
}
