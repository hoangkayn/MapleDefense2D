using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BtnUpLvHero : BaseButton, IHeroUIComponent
{

    [SerializeField] private HeroHoverUI heroHoverUI;

    protected override void OnClick()
    {
        int currentLevel = heroHoverUI.HeroSaveData.currentLevel;
        int cost = heroHoverUI.HeroSO.GetUpgradeCost(currentLevel +1);
        if (!CurrencyManager.Instance.SpendGold(cost))
        {
            PopupManager.Instance.ShowPopup(PopupSpawner.PopupError,"Không Đủ Gold!");
            return;
        } 
        PlayFX();
        GameDataManager.Instance.LevelUpHero(heroHoverUI.HeroSaveData);
        CheckMaxLevelAndHide();
        PopupManager.Instance.ShowPopup(PopupSpawner.PopupSuccess,"Nâng Cấp Thành Công!");
    }
    protected virtual void PlayFX()
    {
        FXSpawner.Instance.Spawn(FXSpawner.Eff_Heal_5, transform.parent.position, Quaternion.identity);
    }

    public void Setup(HeroHoverUI heroHoverUI)
    {
        this.heroHoverUI = heroHoverUI;
        CheckMaxLevelAndHide();
    }
    private void CheckMaxLevelAndHide()
    {
        int lvMax = heroHoverUI.HeroSO.levelStats.Count;
        if (heroHoverUI.HeroSaveData.currentLevel >= lvMax)
        {
            gameObject.SetActive(false);
        }
    }
    
}
