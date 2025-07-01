using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMana : ManaComponent
{
    [SerializeField] protected HeroCtrl heroCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroCtrl();
    }
    protected virtual void LoadHeroCtrl()
    {
        if (heroCtrl != null) return;
        heroCtrl = transform.parent.GetComponent<HeroCtrl>();
    }

    protected override void Setup()
    {
        maxMp = heroCtrl.HeroSO.GetMaxMp(heroCtrl.CurrentLevel);
    }
}
