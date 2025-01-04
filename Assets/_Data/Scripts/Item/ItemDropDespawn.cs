using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }

}
