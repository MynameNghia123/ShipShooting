using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.distanceLimit = 25f; 
    }
}