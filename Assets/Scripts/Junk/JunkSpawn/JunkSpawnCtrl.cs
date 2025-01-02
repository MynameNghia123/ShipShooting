using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnCtrl : SaiMonoBehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints { get =>  junkSpawnPoints; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPonts();
    }
    protected virtual void LoadJunkSpawnPonts()
    {
        if (this.junkSpawnPoints != null) return;
        junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadJunkSpawnPonts", gameObject);
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }
}