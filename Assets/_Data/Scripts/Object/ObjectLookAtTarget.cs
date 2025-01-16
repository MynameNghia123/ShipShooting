using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtTarget : SaiMonoBehavior
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speedRot = 3.0f;

    protected virtual void FixedUpdate()
    {
        this.LootAtTarget();
    }
    public virtual void SetSpeedRot(float speedRot)
    {
        this.speedRot = speedRot;
    }

    protected virtual void LootAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentRot = Quaternion.Lerp(transform.parent.rotation, targetRot, this.speedRot * Time.fixedDeltaTime);
        transform.parent.rotation = currentRot;
    }

}
