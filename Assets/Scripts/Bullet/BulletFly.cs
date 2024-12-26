using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    private void Update()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime); 
    }
}
