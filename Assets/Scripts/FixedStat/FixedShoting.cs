using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedShoting : ObjShooting
{
    protected FixedStatObjCtrl fixedStatObjCtrl => (FixedStatObjCtrl)attackableObjCtrl;
    protected override int GetDameBullet()
    {
        return  fixedStatObjCtrl.fixedStatSO.GetDame();
    }
}
