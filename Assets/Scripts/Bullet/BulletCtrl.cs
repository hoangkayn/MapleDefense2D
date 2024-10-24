using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : BaseMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected BulletImpart bulletImpart;
    public BulletImpart BulletImpart => bulletImpart;
    [SerializeField] protected Transform target;
    public Transform Target => target;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletImpact();
    }
    protected virtual void LoadBulletImpact()
    {
        if (bulletImpart != null) return;
        bulletImpart = transform.GetComponentInChildren<BulletImpart>();
    }
    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        damageSender = transform.GetComponentInChildren<DamageSender>();
    }
    protected  virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
    }
    public virtual void SetTarget(Transform obj)
    {
        target = obj;
    }
}
