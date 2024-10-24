using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : BaseMonoBehaviour
{
    [SerializeField] protected int dame = 1;
     public virtual void Send(DamageReceive damageReceive)
    {
        damageReceive.Deduct(dame);
    }
    public virtual void Send(Transform obj)
    {
        DamageReceive damageReceive = obj.GetComponent<DamageReceive>();
        if (damageReceive == null) return;
        this.Send(damageReceive);
    }
}
