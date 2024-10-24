using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAbstract : BaseMonoBehaviour
{
    [SerializeField] protected HeroCtrl heroCtrl;
    public HeroCtrl HeroCtrl => heroCtrl;
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
}
