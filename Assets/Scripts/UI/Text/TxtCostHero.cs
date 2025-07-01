using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TxtCostHero : BaseText,IHeroUIComponent
{
    private HeroHoverUI heroHoverUI;
    protected override void Start()
    {
        base.Start();
        GameDataManager.OnHeroLevelUp += HandleHeroLevelUp;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        GameDataManager.OnHeroLevelUp -= HandleHeroLevelUp;
    }
    private void HandleHeroLevelUp(HeroSaveData heroSaveData)
    {
        if (this.heroHoverUI.HeroSaveData != heroSaveData) return;
        
            Refesh();
        
    }
    public virtual void Refesh()
    {
        HeroSaveData heroSaveData = this.heroHoverUI.HeroSaveData;
        this.text.text = heroHoverUI.HeroSO.GetUpgradeCost(heroSaveData.currentLevel + 1).ToString();
    }

    public void Setup(HeroHoverUI heroHoverUI)
    {
        this.heroHoverUI = heroHoverUI;
        Refesh();
    }
}
