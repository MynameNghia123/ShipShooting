using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderDamage : SaiMonoBehavior
{
    [SerializeField] protected int dame = 1;

    public virtual void Send(Transform obj)
    {
        RecieverDamage dameReciever = obj.GetComponentInChildren<RecieverDamage>();
        if (dameReciever == null)
        {
            //Debug.LogWarning(transform.name + ": Dame Reciever null", gameObject);
            return;
        }
        this.Send(dameReciever);
        this.CreateImpactFX();
    }
    public virtual void Send(RecieverDamage recieverDamage)
    {
        recieverDamage.Deduct(this.dame);
    }
    protected virtual void CreateImpactFX()
    {
        string nameFx = getImpactFX();

        Vector3 pos = transform.position;
        Quaternion ros = transform.rotation;
        Quaternion rotationEffect = Quaternion.Euler(0, 0, -90);
        Transform fxImpact = FXSpawner.Instance.Spawn(nameFx, pos, rotationEffect * ros);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string getImpactFX()
    {
        return FXSpawner.impact_one;
    }
    public virtual void SetDamage(int damage)
    {
        this.dame = damage;
    }
}
