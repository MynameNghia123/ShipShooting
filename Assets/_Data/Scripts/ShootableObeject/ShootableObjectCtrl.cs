using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : SaiMonoBehavior
{
    [Header("Shootable Object")]
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn { get => despawn; }
    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;
    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting ObjectShooting => objectShooting;
    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;
    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjectShooting();
        this.LoadObjectLookatTarget();
    }
    protected virtual void LoadObjectLookatTarget()
    {
        if (this.objectLookAtTarget != null) return;
        this.objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();
        Debug.Log(transform.name + ": Load ObjectLookAtTarget", gameObject);
    }
    protected virtual void LoadObjectShooting()
    {
        if (objectShooting != null) return;
        objectShooting = GetComponentInChildren<ObjectShooting>();
        Debug.Log(transform.name + ": Load Oject Shooting", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": Load Junk Despawn", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO", gameObject);
    }
    protected abstract string GetObjectTypeString();
}
