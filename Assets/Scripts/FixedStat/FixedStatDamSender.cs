using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FixedStatDamSender : AttackableDamSender
{
    protected FixedStatObjCtrl fixedStatObjCtrl => (FixedStatObjCtrl)attackableObjCtrl;
  
     protected override void Start()
    {
        base.Start();
        this.dame = fixedStatObjCtrl.fixedStatSO.GetDame();
        this.dameSkill = fixedStatObjCtrl.fixedStatSO.GetDameSkill();
    }
}
