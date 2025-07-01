using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackingHpBar : HPBar
{
   
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
   
    public virtual void SetDamageableObjCtrl(DamageableObjCtrl damageableObjCtrl)
    {
        this.damageableObjCtrl = damageableObjCtrl;
    }
    protected override void Dead()
    {
        this.spawner.Despawn(transform);
    }
}
