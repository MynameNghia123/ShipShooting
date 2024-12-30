using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JunkRandom : SaiMonoBehavior
{
    [SerializeField] protected JunkSpawnCtrl junkSpawnCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnCtrl != null) return;
        this.junkSpawnCtrl = GetComponent<JunkSpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected virtual void Start()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Transform rand = junkSpawnCtrl.JunkSpawnPoints.GetRandom();
        Vector3 pos = rand.position;
        Quaternion ros = rand.rotation;
        Transform trans = this.junkSpawnCtrl.JunkSpawner.Spawn(JunkSpawner.junkOne, pos, ros);
        trans.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1.0f);
    }
}
