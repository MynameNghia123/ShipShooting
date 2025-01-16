using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObjectShooting : SaiMonoBehavior
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float ShootTimer = 0f;
    [SerializeField] protected float ShootingDelay = 1f;
    [SerializeField] protected int damage = 1;

    private void Update()
    {
        this.IsShooting();    
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        if(ShootTimer < ShootingDelay )
        {
            this.ShootTimer += Time.fixedDeltaTime;
            return;
        }
        this.ShootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform bulletObj = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.bulletOne, spawnPos, rotation);
        bulletObj.gameObject.SetActive(true);

        BulletCtrl bulletCtrl = bulletObj.GetComponent<BulletCtrl>();
        bulletCtrl.SenderDamage.SetDamage(this.damage);
        bulletCtrl.SetShooter(transform.parent);
        //Debug.Log("Shooting");
    }
    protected abstract bool IsShooting();
}
