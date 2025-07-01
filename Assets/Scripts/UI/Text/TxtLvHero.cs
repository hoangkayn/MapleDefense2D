using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLvHero : BaseText
{
    
    public virtual void Refresh(HeroHoverUI heroHoverUI)
    {
      
          this.text.text = "Lv." + heroHoverUI.HeroSaveData.currentLevel.ToString();
        int levelMax = heroHoverUI.HeroSO.levelStats.Count;
        if (heroHoverUI.HeroSaveData.currentLevel >= levelMax)
        {
            text.color = Color.yellow;
        }
          
    }
}
