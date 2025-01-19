using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehavior
{
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }
    protected override void LoadComponent()
    {
        this.LoadPrefabs();
        this.LoadHoder();
    }
    protected virtual void LoadHoder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + " : LoadHolder", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        // list ban đầu sẽ là rỗng sau khi chạy program sẽ add dần vào
        Transform prefabObj = transform.Find("Prefabs");

        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
            Debug.Log(prefab.name + " :loadPrefabs ");
        }
        Debug.Log(transform.name + " :loadPrefabs ");
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
            Debug.Log(transform.name + " :loadPrefabs ");
        }
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);

        this.spawnedCount--;
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform prefab = GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found : " + prefabName);
            return null;
        }


        return Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);

        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in prefabs)
        {
            if(prefab.name == prefabName) 
                return prefab;
        }
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
    public virtual void Hold(Transform newPrefab)
    {
        newPrefab.parent = this.holder; 
    }
}
