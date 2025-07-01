using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLookTarget : BulletFly
{

    protected override void FixedUpdate()
    {
        SetTarget();
        LootAtTarget();
        base.FixedUpdate();
    }
    protected virtual void LootAtTarget()
    {
        Vector3 diff = this.target.position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }
   
    protected virtual void SetTarget()
    {
        target = bulletCtrl.Target;
    }

}
