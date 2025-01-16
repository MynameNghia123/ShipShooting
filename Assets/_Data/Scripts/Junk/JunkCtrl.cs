using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn;  }
    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjectSO();
    }
    protected virtual void LoadDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load Despawn", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO", gameObject);
    }
}
 