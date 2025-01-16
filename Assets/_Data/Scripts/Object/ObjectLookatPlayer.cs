using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookatPlayer : ObjectLookAtTarget
{
    [Header("Look Player")]
    [SerializeField] protected GameObject lookAtTarget;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (this.lookAtTarget != null) return;
        this.lookAtTarget = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ":Load Player", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = this.lookAtTarget.transform.position;
        this.targetPosition.z = 0;
    }
}
