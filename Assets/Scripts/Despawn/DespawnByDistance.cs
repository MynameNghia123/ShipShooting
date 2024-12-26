using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distanceLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera mainCamere;

    protected override void LoadComponent()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera() 
    {
        if (this.mainCamere != null) return;
        mainCamere = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + ": LoadCamera ");
    }

    protected override bool IsCanDestroy()
    {
        this.distance = Vector3.Distance(transform.position, mainCamere.transform.position);
        if(this.distance < distanceLimit) return false;
        return true;
    }
}
