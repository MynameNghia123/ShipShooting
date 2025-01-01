using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FollowTarget : SaiMonoBehavior
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 7.0f;
    protected void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        if (this.target == null) return;
        transform.position = Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * this.speed);
    }
}
