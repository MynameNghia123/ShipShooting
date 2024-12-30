using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 7.0f;
    }
}
