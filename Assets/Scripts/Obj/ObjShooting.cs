using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ObjShooting : AttackableObjAbstract
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
      [SerializeField] protected float limitDis = 5f;
    public float LimitDis => limitDis;
    public event Action OnShoot;

    void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    
    public virtual bool IsShooting()
    {
        Transform target = attackableObjCtrl.ObjDetection.Target;
        if (target == null) return isShooting = false;
        float distance = Vector3.Distance(target.position,transform.parent.position);

        return this.isShooting = distance <= limitDis;
       
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        OnShoot?.Invoke();
        if (attackableObjCtrl.Abilities != null && attackableObjCtrl.Abilities.SkillActiving) return;
        if (attackableObjCtrl.Anim != null)
        {
            attackableObjCtrl.Anim.SetTrigger("Attack");
        }
        Vector3 spawnPos = transform.position + new Vector3(0.5f, 0, 0);
        Quaternion rotation = transform.parent.rotation;
        string bulletName;

        bulletName = attackableObjCtrl.DamageableObjSO.bulletName.ToString();
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        Transform targetObj = attackableObjCtrl.ObjDetection.Target;
        bulletCtrl.SetTarget(targetObj);
        bulletCtrl.SetShooter(transform.parent);
        bulletCtrl.PlaySFX(attackableObjCtrl.DamageableObjSO.soundData);
        bulletCtrl.BulletDamSender.SetBulletDame(GetDameBullet());
    }
    protected abstract int GetDameBullet();
}
