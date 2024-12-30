using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }

    public static string junkOne = "Junk_1";

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null)
        {
            Debug.Log("Only 1 JunkSpawner exist in Game");
            return;
        }
        JunkSpawner.instance = this;
    }
}
