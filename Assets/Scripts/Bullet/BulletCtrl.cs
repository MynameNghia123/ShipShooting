using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehavior
{
    [SerializeField] protected SenderDamage senderDamage;
    public SenderDamage SenderDamage { get => senderDamage; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSenderDame();
        this.LoadSBulletDespawn();
    }
    protected virtual void LoadSenderDame()
    {
        if (this.senderDamage != null) return;
        this.senderDamage = GetComponentInChildren<SenderDamage>();
        Debug.Log(transform.name + ": LoadSenderDamage", gameObject);
    }
    protected virtual void LoadSBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }
}
