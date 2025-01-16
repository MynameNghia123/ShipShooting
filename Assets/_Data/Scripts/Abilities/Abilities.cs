using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : SaiMonoBehavior
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl => abilityObjectCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityObjectCtrl();
    }
    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();
        Debug.Log(transform.name + ":Load Ability Object Ctrl", gameObject);
    }

}
