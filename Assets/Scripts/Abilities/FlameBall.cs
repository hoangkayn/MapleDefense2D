using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBall : BaseAbility
{
    [SerializeField] protected HeroCtrl heroCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroCtrl();
    }
    protected virtual void LoadHeroCtrl()
    {
        if (heroCtrl != null) return;
        heroCtrl = transform.parent.parent.GetComponent<HeroCtrl>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Shoot();
    }
    protected virtual void Shoot()
    {
        if (!isReady) return;
        attackableObjCtrl.Anim.SetTrigger("Attack");
        Vector3 spawnPos = transform.position + new Vector3(-0.5f, 0, 0);

        Transform newBullet = BulletSpawner.Instance.Spawn("FlameBall", spawnPos, Quaternion.identity);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetTarget(attackableObjCtrl.ObjDetection.Target);
        bulletCtrl.SetShooter(transform.parent.parent);
        bulletCtrl.BulletDamSender.SetBulletDame(heroCtrl.HeroSO.GetDameSkill(heroCtrl.CurrentLevel));
        AudioManager.Instance.PlayOneShot("FireBall");
        isReady = false;
          abilities.SetIsActive(false);
    }
}
