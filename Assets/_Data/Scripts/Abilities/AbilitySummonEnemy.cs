using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int limitEnemy = 2;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.clearDeadMinions();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<Spawner>();
        Debug.Log(transform.name + ":Load spawner", gameObject);
    }
    protected override void Summoning()
    {
        if (this.minions.Count >= limitEnemy) return;
        base.Summoning();
    }
    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);   
        return minion; 
    }
    protected virtual void clearDeadMinions()
    {
        foreach(Transform minion in this.minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                break;
            }
        }
    }
}
