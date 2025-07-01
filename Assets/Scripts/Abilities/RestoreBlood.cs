using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreBlood: BaseAbility
{
    public HeroCtrl heroCtrl => (HeroCtrl)attackableObjCtrl; 
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Healing();
    }
    protected virtual void Healing()
    {
        if (!isReady) return;
        FXSpawner.Instance.Spawn(FXSpawner.RestoreBlood, transform.parent.position, Quaternion.identity);
        Transform prefabTxtHeal = FXSpawner.Instance.Spawn(FXSpawner.TextHealHP, transform.parent.position, Quaternion.identity);
    TextValue textHeal = prefabTxtHeal.GetComponent<TextValue>();
        float percentHeal = heroCtrl.HeroSO.GetHpPercentHeal(heroCtrl.CurrentLevel) / 100f;
      float maxHp = heroCtrl.HeroSO.GetMaxHp(heroCtrl.CurrentLevel);   
       int healAmount = Mathf.RoundToInt(percentHeal * maxHp);
        string str = "+" + healAmount;
        textHeal.SetValue(str);
        attackableObjCtrl.DamageReceive.AddHP(healAmount);
        isReady = false;
        abilities.SetIsActive(false);
    }
}
