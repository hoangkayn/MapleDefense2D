using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    public override void Send(DamageReceive damageReceive)
    {
        base.Send(damageReceive);
        this.DestroyObj();
    }
    protected virtual void DestroyObj()
    {
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }
}
