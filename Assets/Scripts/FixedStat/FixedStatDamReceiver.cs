using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FixedStatDamReceiver : AttackDamReciver
{
  public FixedStatObjCtrl fixedStatObjCtrl => (FixedStatObjCtrl)attackableObjCtrl;
  protected override void Reborn()
  {
    this.maxHp = fixedStatObjCtrl.fixedStatSO.GetMaxHp();
    base.Reborn();
  }   
}
