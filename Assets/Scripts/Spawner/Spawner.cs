using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehavior
{

    [SerializeField] private List<Transform> prefabs;

    protected override void Awake()
    {
        this.HidePrefabs();
    }

    protected override void LoadComponent()
    {
        if (prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");

        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }
        Debug.Log(transform.name +" :loadPrefabs ", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform prefab = GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found : " + prefabName);
            return null;
        }
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
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
