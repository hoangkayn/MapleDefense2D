using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : BulletAbstract
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 100f;
    [SerializeField] protected float speed = 0.1f;

    protected virtual void FixedUpdate()
    {
       this.LootAtTarget();
        this.Flying();
    }

    public virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }

    protected virtual void LootAtTarget()
    {
        this.targetPosition = bulletCtrl.Target.position;
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }
    protected virtual void Flying()
    {
        transform.parent.Translate(speed * Vector2.right);
    }
}
