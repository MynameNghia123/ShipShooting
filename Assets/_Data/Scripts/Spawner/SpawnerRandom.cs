using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : SaiMonoBehavior
{
    [SerializeField] protected SpawnerCtrl spawnCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }
    protected void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform rand = spawnCtrl.SpawnPoints.GetRandom();

        Vector3 pos = rand.position;
        Quaternion ros = rand.rotation;

        Transform prefab = this.spawnCtrl.Spawner.RandomPrefab();
        Transform trans = this.spawnCtrl.Spawner.Spawn(prefab, pos, ros);
        trans.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnCtrl.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
