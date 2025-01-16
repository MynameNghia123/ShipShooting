using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectAbtract : SaiMonoBehavior
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObject();
    }
    protected virtual void LoadShootableObject()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": Load Shootable Oject", gameObject);
    }
}
