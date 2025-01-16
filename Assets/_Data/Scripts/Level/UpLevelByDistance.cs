using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpLevelByDistance : Level
{
    [Header("Up Level By Distance")]
    [SerializeField] protected Transform target;

    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel = 10f;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void Leveling()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, this.target.position);
        int newLevel = this.GetLevelByDis();
        this.SetLevel(newLevel);
    }
    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance/ this.distancePerLevel);
    }
}
