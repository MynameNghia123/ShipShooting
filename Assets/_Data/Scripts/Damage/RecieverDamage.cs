using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class RecieverDamage : SaiMonoBehavior
{
    [Header("Reciever Damage")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected bool  isDead = false;

   protected override void OnEnable()
    {
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + ": Load Collider", gameObject);
    }
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }
    public virtual void add(int hp)
    {
        if(this.isDead) return;

        this.hp += hp;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Deduct(int hp)
    {
        if(this.isDead) return;

        this.hp -= hp;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();
}
