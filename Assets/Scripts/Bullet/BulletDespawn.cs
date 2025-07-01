using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadBulletDespawn() {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }
       
    protected override bool CanDespawn()
    {
        if (bulletCtrl.Target == null) return true;
        return bulletCtrl.Target.parent.gameObject.activeSelf == false;
    }

    public override void DespawnObject()
    {
         BulletSpawner.Instance.Despawn(transform.parent);
    }
}
