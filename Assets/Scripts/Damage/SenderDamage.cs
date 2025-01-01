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
            Debug.LogWarning(transform.name + ": Dame Reciever null", gameObject);
            return;
        }
        this.Send(dameReciever);
    }
    public virtual void Send(RecieverDamage recieverDamage)
    {
        recieverDamage.Deduct(this.dame);
    }
}
