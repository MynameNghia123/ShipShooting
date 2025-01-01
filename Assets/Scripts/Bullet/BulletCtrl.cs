using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehavior
{
    [SerializeField] protected SenderDamage senderDamage;
    public SenderDamage SenderDamage { get => senderDamage; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSenderDame();
    }
    protected virtual void LoadSenderDame()
    {
        if (this.senderDamage != null) return;
        this.senderDamage = GetComponentInChildren<SenderDamage>();
        Debug.Log(transform.name + ": LoadSenderDamage", gameObject);
    }
}
