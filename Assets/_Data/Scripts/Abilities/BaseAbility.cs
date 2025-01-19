using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public abstract class BaseAbility : SaiMonoBehavior
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;
    [SerializeField] protected float timer = 2.0f;
    [SerializeField] protected float delay = 2.0f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Update()
    {
        
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.Log(transform.name + ":Load abilities", gameObject);
    }
    protected virtual void Active()
    {
        this.timer = 0;
        this.isReady = false;
    }
}
