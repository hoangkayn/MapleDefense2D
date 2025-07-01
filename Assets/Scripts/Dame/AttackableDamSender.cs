using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackableDamSender : DamageSender
{
    [SerializeField] protected AttackableObjCtrl attackableObjCtrl;
    [SerializeField] protected float dameSkill;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackableObjCtrl();
    }
    protected virtual void LoadAttackableObjCtrl()
    {
        if (attackableObjCtrl != null) return;
        attackableObjCtrl = transform.parent.GetComponent<AttackableObjCtrl>();
    }

    public override void Send(Transform obj)
    {
        base.Send(obj);
        ManaComponent manaComponent = attackableObjCtrl.ManaComponent;
        if (manaComponent == null) return;
        manaComponent.AddMana(dame * 0.5f);
    }
     public virtual void SendDameSkill(Transform obj)
    {
        DamageReceive damageReceive = obj.GetComponent<DamageReceive>();
        if (damageReceive == null) return;
        this.SendDameSkill(damageReceive);
        
    }
     public virtual void SendDameSkill(DamageReceive damageReceive)
    {
         damageReceive.DeductHP(dameSkill);
        this.CreatTextDamage(damageReceive.transform.position,dameSkill);
    }
}
