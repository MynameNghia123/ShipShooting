using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RecieverDamage : SaiMonoBehavior
{
    [Header("Reciever Damage")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected bool  isDead = false;

    protected override void Start()
    {
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        Debug.Log(transform.name + ": Load Collider", gameObject);
    }
    protected virtual void Reborn()
    {
        this.hp = this.hpMax;
    }
    public virtual void add(int hp)
    {
        this.hp += hp;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Deduct(int hp)
    {
        this.hp -= hp;
        if (this.hp < 0) this.hp = 0;
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
