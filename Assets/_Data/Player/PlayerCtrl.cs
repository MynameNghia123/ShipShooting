using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SaiMonoBehavior
{

    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PLayerPickup playerPickup;
    public PLayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PLayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);
    }
}
