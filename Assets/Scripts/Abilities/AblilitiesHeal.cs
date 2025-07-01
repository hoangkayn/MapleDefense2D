using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AblilitiesHeal : Abilities
{
    protected override void OnEnable()
    {
        base.OnEnable();

        attackableObjCtrl.ManaComponent.OnManaFull += HandleFullMana;
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        attackableObjCtrl.ManaComponent.OnManaFull -= HandleFullMana;
    }
    protected virtual void HandleFullMana()
    {
        ManaComponent manaComponent = attackableObjCtrl.ManaComponent;
        manaComponent.SpendMana();
        ActiveSkill();
    }
    
}
