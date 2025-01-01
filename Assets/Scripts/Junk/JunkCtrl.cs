using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn;  }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadJunkDespawn();
    }
    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load Junk Despawn", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    public virtual Transform GetModel()
    {
        return model;
    }
}
 