using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearingWithoutShoot : ShootableObjectAbtract, IObjectAppearingObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjectAppearing objectAppearing;
    public ObjectAppearing ObjectAppearing => objectAppearing;
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected virtual void RegisterAppearEvent()
    {
        this.objectAppearing.ObeserverAdd(this);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjectAppearing();
    }
    protected virtual void LoadObjectAppearing()
    {
        if(this.objectAppearing != null) return;
        this.objectAppearing = GetComponent<ObjectAppearing>();
        Debug.Log(transform.name + "Load Object Appearing", gameObject);
    }

    public void OnAppearStart()
    {
        this.ShootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
        this.ShootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(false);

    }

    public void OnAppearFinish()
    {
        this.ShootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);
        this.ShootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(true);

    }
}
