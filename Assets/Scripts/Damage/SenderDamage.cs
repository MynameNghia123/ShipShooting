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
            Debug.Log(transform.name + ": Dame Reciever null", gameObject);
            return;
        }
        this.Send(dameReciever);
    }
    public virtual void Send(RecieverDamage recieverDamage)
    {
        recieverDamage.Deduct(this.dame);
        this.DestroyObject();
    }
    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
