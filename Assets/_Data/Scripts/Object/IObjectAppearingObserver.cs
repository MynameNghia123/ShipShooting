using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectAppearingObserver 
{
    public abstract void OnAppearStart();
    public abstract void OnAppearFinish();
}
