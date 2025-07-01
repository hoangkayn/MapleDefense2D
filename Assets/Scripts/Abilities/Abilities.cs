using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : AttackableObjAbstract
{
    [SerializeField] protected List<BaseAbility> baseAbilities;
    [SerializeField] protected bool skillActiving = false;
    public bool SkillActiving => skillActiving;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBaseAbilities();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        skillActiving = false;
    }
    public virtual void SetIsActive(bool b)
    {
        skillActiving = b;
    }
  
    protected virtual void LoadBaseAbilities()
    {
        if (baseAbilities.Count > 0) return;
        BaseAbility[] array = GetComponentsInChildren<BaseAbility>();
        baseAbilities.AddRange(array);
    }
    public virtual void ActiveSkill()
    {
        skillActiving = true;
        foreach (BaseAbility baseAbility in baseAbilities)
        {
            baseAbility.Active();
        }
    }
   
}
