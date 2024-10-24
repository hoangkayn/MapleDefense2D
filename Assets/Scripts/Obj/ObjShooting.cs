using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ObjShooting : ShootableObjAbstract
{
   
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;

    void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        if (shootableObjCtrl.Anim != null)
        {
            shootableObjCtrl.Anim.SetTrigger("Attack");
        }
        Vector3 spawnPos = transform.position + new Vector3(0.5f,0,0);
        Quaternion rotation = transform.parent.rotation;
        string bulletName = this.shootableObjCtrl.ObjMoveableSO.bulletName.ToString();
       
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        DamageReceive damageReceive = shootableObjCtrl.ObjDetection.Target.GetComponentInChildren<DamageReceive>();
        if ( damageReceive == null) return;
          bulletCtrl.SetTarget(damageReceive.transform);
     
    }

    protected abstract bool IsShooting();
}
