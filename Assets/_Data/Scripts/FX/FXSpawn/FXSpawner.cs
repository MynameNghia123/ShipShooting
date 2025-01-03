using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    [SerializeField] protected static FXSpawner instance;
    public static FXSpawner Instance => instance;
    public static string smoke_one = "Smoke_1";
    public static string impact_one = "Impact_1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null)
        {
            Debug.LogWarning("Only 1 FXSpawner exist in Game");
            return;
        }
        FXSpawner.instance = this;
    }
}
