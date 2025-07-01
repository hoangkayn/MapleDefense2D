using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AblilitiesAttack : Abilities
{
    protected override void OnEnable()
    {
        base.OnEnable();
        if (attackableObjCtrl.Attack != null)
        {
            attackableObjCtrl.Attack.OnAttack += HandleCanAttack;
        }
        if (attackableObjCtrl.ObjShooting != null)
        {
             attackableObjCtrl.ObjShooting.OnShoot += HandleCanAttack;
        }
     
        
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (attackableObjCtrl.Attack != null)
        {
            attackableObjCtrl.Attack.OnAttack -= HandleCanAttack;
        }
        if (attackableObjCtrl.ObjShooting != null)
        {
             attackableObjCtrl.ObjShooting.OnShoot -= HandleCanAttack;
        }
     
    }
      protected virtual void HandleCanAttack()
    {
        ManaComponent manaComponent = attackableObjCtrl.ManaComponent;
        if (!manaComponent.HasEnoughMana()) return;
        manaComponent.SpendMana();
        ActiveSkill();
    }
}
