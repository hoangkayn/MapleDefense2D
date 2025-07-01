using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MPBar : Bar
{
    [SerializeField] protected AttackableObjCtrl attackableObjCtrl;
    public AttackableObjCtrl AttackableObjCtrl => attackableObjCtrl;

     [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;
    [SerializeField] protected Spawner spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFollowTarget();
        this.LoadSpawner();
     
    }

     protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent.parent.GetComponent<Spawner>();
    }
    
    
     protected virtual void LoadFollowTarget()
    {
        if (followTarget != null) return;
        followTarget = transform.GetComponent<FollowTarget>();
    }
    public virtual void SetTarget(Transform obj)
    {
        this.followTarget.SetTarget(obj);
    }
        protected override void Showing()
    {
        if (attackableObjCtrl == null) return;
        bool isDead = attackableObjCtrl.DamageReceive.IsDead();
        if (isDead) spawner.Despawn(transform);
        if (attackableObjCtrl == null) return;
        float mp = attackableObjCtrl.ManaComponent.CurrentMp;
        float maxMp = attackableObjCtrl.ManaComponent.MaxMp;
        this.slider.SetValue(mp);
        this.slider.SetMaxValue(maxMp);
    }
     public virtual void SetAttackableObjCtrl(AttackableObjCtrl attackableObjCtrl)
    {
        this.attackableObjCtrl = attackableObjCtrl;
    }
}
