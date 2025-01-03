using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SaiMonoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }
    protected virtual void Start()
    {
        // for ovveride
    }
    protected virtual void LoadComponent()
    {
        // for ovveride
    }
    protected virtual void ResetValue()
    {
        // for ovveride
    }
    protected virtual void OnEnable()
    {
        // for ovveride
    }
}
