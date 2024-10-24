using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingByDistance : ObjShooting
{
    [SerializeField] protected float limitDis = 5f;
    protected override bool IsShooting()
    {
        Transform target = shootableObjCtrl.ObjDetection.Target;
        if (target == null) return isShooting = false;
        float distance = Vector3.Distance(target.position,transform.parent.position);

        return this.isShooting = distance <= limitDis;
       
    }
}
