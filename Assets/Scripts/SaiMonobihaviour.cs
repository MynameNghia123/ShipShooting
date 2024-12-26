using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SaiMonoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        // for ovveride
    }
}
