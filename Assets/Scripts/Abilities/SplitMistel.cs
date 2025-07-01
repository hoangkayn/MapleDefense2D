using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMistel : BaseAbility
{
    public HeroCtrl heroCtrl => (HeroCtrl)attackableObjCtrl;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Shoot();
    }
    protected virtual void Shoot()
    {
        if (!isReady) return;

        heroCtrl.Anim.SetTrigger("Attack");
        Vector3 spawnPos = transform.position;
        Transform newBullet = BulletSpawner.Instance.Spawn("SplitMistel", spawnPos, Quaternion.identity);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent.parent);
        bulletCtrl.PlaySFX(heroCtrl.DamageableObjSO.soundData);
        bulletCtrl.BulletDamSender.SetBulletDame(heroCtrl.HeroSO.GetDameSkill(heroCtrl.CurrentLevel));
        FreezeBulletImpact freezeBulletImpact = bulletCtrl.GetComponentInChildren<FreezeBulletImpact>();
        freezeBulletImpact.SetFreezeDuration(heroCtrl.HeroSO.GetFreezeTime(heroCtrl.CurrentLevel));
        isReady = false;
        abilities.SetIsActive(false);
    }
}
