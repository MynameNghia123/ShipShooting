using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : SaiMonoBehavior
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance;
    [SerializeField] protected float minDistance = 1.0f;
    
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed );
        transform.parent.position = newPos;
    }
}