using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveForward : ObjectMovement
{
    [SerializeField] protected Transform target;
    [SerializeField] protected EnemyCtrl x;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDistance();
    }
    protected virtual void LoadDistance()
    {
        if (target != null) return;
        this.target = transform.Find("Look");
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = target.position;
        this.targetPosition.z = 0;
    }
}