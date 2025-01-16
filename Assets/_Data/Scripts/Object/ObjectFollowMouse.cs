using System.Collections;
using UnityEngine;

public class ObjectFollowMouse: ObjectLookAtTarget
{
   // [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}
