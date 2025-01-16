using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class ShipFollowTarget : ObjectMovement
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFollowTarget();
    }
    protected virtual void LoadFollowTarget()
    {
        this.target = GameObject.Find("Ship").transform;
        Debug.Log(transform.name + ":Load FollowTarget", gameObject);
    }
    protected override void FixedUpdate()
    {
        this.GetTargetPosition();
        base.FixedUpdate();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }
}