using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed;

    protected void FixedUpdate()
    {
        this.worldPosition = Camera.main
    }
}
