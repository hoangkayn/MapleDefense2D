using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl() {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponentInChildren<BulletCtrl>();
    }
    public virtual void SetBulletDame(int value)
    {
        this.dame = value;
    }
    public override void Send(Transform obj)
    {
        base.Send(obj);
        AttackableObjCtrl attackableObjCtrl = bulletCtrl.Shooter.GetComponent<AttackableObjCtrl>();
        ManaComponent manaComponent = attackableObjCtrl.ManaComponent;
        if (manaComponent == null) return;
        manaComponent.AddMana(dame * 0.5f);
    }

  
}
