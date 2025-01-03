using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn;  }
    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => junkSO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
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
    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO", gameObject);
    }
}
 