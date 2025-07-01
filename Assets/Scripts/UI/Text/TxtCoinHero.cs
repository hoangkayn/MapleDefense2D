using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public  class TxtCoinHero : BaseText
{
    [SerializeField] protected BtnBuyHero btnBuyHero;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnBuyHero();
    }
    protected virtual void LoadBtnBuyHero()
    {
        if (btnBuyHero != null) return;
        btnBuyHero = transform.parent.parent.GetComponent<BtnBuyHero>();
    }
    protected override void Start()
    {
        base.Start();
        HeroSpawner.Instance.OnHeroesSetupDone += SetText;
        if (HeroSpawner.Instance.IsSetupDone)
        {
            SetText();
        }
    }
    protected virtual void SetText()
    {
          HeroCtrl heroCtrl = HeroSpawner.Instance.GetHeroCtrl(btnBuyHero.HeroSO.heroId);
        this.text.text = btnBuyHero.HeroSO.GetPricent(heroCtrl.CurrentLevel).ToString();
    }
}
