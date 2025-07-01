using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : AttackableObjCtrl
{
    public HeroSO HeroSO => (HeroSO)damageableObjSO;
    [SerializeField] private int currentLevel;
    public int CurrentLevel => currentLevel;
    public virtual void SetLevel(int value)
    {
        currentLevel = value;
    }
   
    protected override string GetTypeObj()
    {
        return ObjType.Hero.ToString();

    }
   
}
    
