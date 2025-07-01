using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : BaseMonoBehaviour
{
    [SerializeField] protected BulletDamageSender bulletDamSender;
    public BulletDamageSender BulletDamSender => bulletDamSender;
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected BulletImpart bulletImpart;
    public BulletImpart BulletImpart => bulletImpart;
    [SerializeField] protected Transform target;
    public Transform Target => target;
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletImpact();
    }
    public virtual void SetShooter(Transform obj)
    {
        this.shooter = obj;
    }
    public virtual void PlaySFX(SoundData soundData)
    {
        AudioManager.Instance.PlayOneShot(soundData.id);
    }
    protected virtual void LoadBulletImpact()
    {
        if (bulletImpart != null) return;
        bulletImpart = transform.GetComponentInChildren<BulletImpart>();
    }
    protected virtual void LoadDamageSender()
    {
        if (bulletDamSender != null) return;
        bulletDamSender = transform.GetComponentInChildren<BulletDamageSender>();
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
