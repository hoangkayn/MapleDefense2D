using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCtrl : DamageableObjCtrl
{
    protected override string GetTypeObj()
    {
        return ObjType.House.ToString();
    }
}
