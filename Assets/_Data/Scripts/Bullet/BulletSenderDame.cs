using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSenderDame : SenderDamage
{
    [Header("Bullet Sender Dame")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    public override void Send(RecieverDamage recieverDamage)
    {
        base.Send(recieverDamage);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
