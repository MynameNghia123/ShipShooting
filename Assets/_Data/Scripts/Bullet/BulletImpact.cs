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
        this.CreateImpactFX(other);
    }
    protected virtual void CreateImpactFX(Collider other)
    {
        string nameFx = getImpactFX();


        //Vector3 hitPos = transform.position;
        //Quaternion hitRot = transform.rotation;
        //Transform fxImpact = FXSpawner.Instance.Spawn(nameFx, hitPos, hitRot);
        //fxImpact.gameObject.SetActive(true);


        Vector3 pos = transform.position;
        Quaternion ros = transform.rotation;
        Quaternion rotationEffect = Quaternion.Euler(0, 0, -90);
        Transform fxImpact = FXSpawner.Instance.Spawn(nameFx, pos, rotationEffect * ros);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string getImpactFX()
    {
        return FXSpawner.impact_one;
    }
}
