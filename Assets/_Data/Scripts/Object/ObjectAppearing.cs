using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : SaiMonoBehavior
{
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjectAppearingObserver> observers = new List<IObjectAppearingObserver>();

    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;
    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }
    protected abstract void Appearing();
    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }
    public virtual void ObeserverAdd(IObjectAppearingObserver observer)
    {
        this.observers.Add(observer);
    }
    public virtual void OnAppearStart()
    {
        foreach(IObjectAppearingObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }
    public virtual void OnAppearFinish()
    {
        foreach (IObjectAppearingObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }
}
