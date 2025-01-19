using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpwaner : Spawner
{
    private static MotherShipSpwaner instance;
    public static MotherShipSpwaner Instance { get => instance; }
    

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpwaner.instance != null)
        {
            Debug.LogWarning("Only 1 EnemySpawner exist in Game");
            return;
        }
        MotherShipSpwaner.instance = this;
    }

}
