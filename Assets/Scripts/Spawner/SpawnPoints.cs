using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class SpawnPoints : SaiMonoBehavior
{
    [SerializeField] protected List<Transform> Points;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (Points.Count > 0) return;
        foreach (Transform trans in transform)
        {
            Points.Add(trans);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0,Points.Count);
        return Points[rand];
    }
}
