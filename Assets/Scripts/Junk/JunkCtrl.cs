using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
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
