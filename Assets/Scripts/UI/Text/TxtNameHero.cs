using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtNameHero : BaseText
{
    public virtual void Refresh(HeroHoverUI heroHoverUI)
    {
      
          this.text.text = heroHoverUI.HeroSaveData.heroId.ToString();
        int levelMax = heroHoverUI.HeroSO.levelStats.Count;
        if (heroHoverUI.HeroSaveData.currentLevel >= levelMax)
        {
            text.color = Color.yellow;
        }
          
    }
}
