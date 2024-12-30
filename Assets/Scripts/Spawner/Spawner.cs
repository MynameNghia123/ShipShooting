using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehavior
{
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] private List<Transform> poolObjs;
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
        }
        Debug.Log(transform.name + " :loadPrefabs ");
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform prefab = GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found : " + prefabName);
            return null;
        }
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
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
}
