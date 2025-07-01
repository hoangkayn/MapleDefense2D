using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : FixedStatObjCtrl
{
    protected override string GetTypeObj()
    {
        return ObjType.Tower.ToString();
    }
}
