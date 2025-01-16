using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingBymouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
