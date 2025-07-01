using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageReceive : AttackDamReciver
{
    public HeroCtrl heroCtrl => (HeroCtrl)attackableObjCtrl;

    protected override void DespawnObj(Transform obj)
    {
        HeroSpawner.Instance.Despawn(obj);
    }

    protected override void Reborn()
    {
        this.maxHp = heroCtrl.HeroSO.GetMaxHp(heroCtrl.CurrentLevel);
        base.Reborn();
    }
  

}
