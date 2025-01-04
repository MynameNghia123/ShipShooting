using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRecieverDame : RecieverDamage
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
        this.Reborn();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        //The Animation of junk which is destroy by something
        this.OnDeadFX();
        //Collect Junk into pooling object
        this.junkCtrl.JunkDespawn.DespawnObject();
        // Drop Item
        this.OnDeadDrop();
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.JunkSO.dropList, dropPos, dropRot);
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
        this.hpMax = junkCtrl.JunkSO.maxHp;
        base.Reborn();
    }
}

