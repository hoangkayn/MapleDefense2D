using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FixedStatObjCtrl : AttackableObjCtrl
{
    public FixedStatSO fixedStatSO => (FixedStatSO)damageableObjSO;
}
