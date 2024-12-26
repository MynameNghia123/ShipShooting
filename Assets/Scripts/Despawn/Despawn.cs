using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehavior
{

    protected void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!IsCanDestroy()) return;
        this.DespawnObject();
    }
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }


    protected abstract bool IsCanDestroy();
}
