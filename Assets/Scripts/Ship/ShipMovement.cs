using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f; 
    [SerializeField] protected Vector3 targetPosition;
    void Update()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - this.transform.parent.position; // tính tọa độ hướng đi
        diff.Normalize();                                                    // chuản hóa Vector đưa dộ lớn về 1 
                                                                             // để giữ lại hướng đi ban đầu
         float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;           // Mathf.Atan2: trả về radian Tan của y và x
                                                                             // Mathf.Rad2Deg trả về 1 radian = ? degree
        transform.parent.rotation = Quaternion.Euler(0f, 0f,  rot_z);   // phép xoay
                                                                                    
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed * Time.deltaTime);
        transform.parent.position = newPos;
    }
}
