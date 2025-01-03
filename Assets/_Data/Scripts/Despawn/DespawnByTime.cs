using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float timeLimit = 2.0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }
    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }
    protected override bool IsCanDestroy()
    {
        this.timer += Time.fixedDeltaTime;
        if (timer < timeLimit) return false;
        return true;
    }
}
