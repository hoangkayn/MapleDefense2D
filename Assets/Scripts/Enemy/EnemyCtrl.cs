using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : FixedStatObjCtrl
{
    protected override string GetTypeObj()
    {
        return ObjType.Enemy.ToString();
    }
}
