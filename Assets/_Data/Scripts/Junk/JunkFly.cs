using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjectFly
{
    [SerializeField] protected int minRan = -7;
    [SerializeField] protected int maxRan = 7;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 1.0f;
    }

    protected override void OnEnable()
    {
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GetCamPos();
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(minRan, maxRan);
        camPos.z += Random.Range(minRan, maxRan);

        Vector3 diff = camPos - objPos;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

       // this.direction = (camPos - transform.position).normalized;

      //  Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }
    protected virtual Vector3 GetCamPos()
    {
        if (GameCtrl.Instance == null) return Vector3.zero;
        Vector3 camPos = GameCtrl.Instance.GetCamera().transform.position;
        return camPos;
    }
}
