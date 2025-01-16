using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootringByDistance : ObjectShooting
{
    [Header("Shooting by Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float limitDistance = 3.0f;
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = distance < limitDistance;
        return this.isShooting;
    }
}
