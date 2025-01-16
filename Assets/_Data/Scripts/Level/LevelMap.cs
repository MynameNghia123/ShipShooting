using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : UpLevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }
    protected virtual void MapSetTarget()
    {
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
