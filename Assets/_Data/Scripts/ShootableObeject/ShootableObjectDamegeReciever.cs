using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamegeReciever : RecieverDamage
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObjectCtrl();
    }
    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": Load LoadShootableObjectCtrl", gameObject);
    }
    protected override void OnDead()
    {

        //The Animation of junk which is destroy by something
        this.OnDeadFX();
        //Collect Junk into pooling object
        this.shootableObjectCtrl.Despawn.DespawnObject();
        // Drop Item
        this.OnDeadDrop();
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke_one;
    }
    public override void Reborn()
    {
        this.hpMax = shootableObjectCtrl.ShootableObject.maxHp;
        base.Reborn();
    }
}
