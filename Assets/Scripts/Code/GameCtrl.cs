using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : SaiMonoBehavior
{
    [SerializeField] protected static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }
    [SerializeField] protected Camera mainCamera;
    protected override void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
    public virtual Camera GetCamera()
    {
        return mainCamera;
    }
}
