using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamSender : AttackableDamSender
{
    protected HeroCtrl heroCtrl => (HeroCtrl)attackableObjCtrl;
    protected override string GetNameText()
    {
        return FXSpawner.TextDamageHero;
    }
    protected override void Start()
    {
        base.Start();
        this.dame = heroCtrl.HeroSO.GetDame(heroCtrl.CurrentLevel);
        this.dameSkill = heroCtrl.HeroSO.GetDameSkill(heroCtrl.CurrentLevel);
    }
}
