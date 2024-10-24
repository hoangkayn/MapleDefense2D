using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : ShootableObjAbstract
{

    [SerializeField] protected float limitDis = 5f;
    [SerializeField] protected float speed = 0.01f;
   // [SerializeField] protected Vector3 direction = Vector3.right;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        Transform target = this.shootableObjCtrl.ObjDetection.Target;
        if (target == null)
        {
            transform.parent.Translate(-shootableObjCtrl.Model.right * speed);
            shootableObjCtrl.Anim.SetBool("isMoving",true);
            return;
        }
        float distance = Vector3.Distance(transform.parent.position, target.position);
        if (distance <= limitDis)
        {
            shootableObjCtrl.Anim.SetBool("isMoving", false);
            return;
        }
        if (shootableObjCtrl.DamageReceive.IsDead()) return;
        transform.parent.Translate(-shootableObjCtrl.Model.right * speed);
        shootableObjCtrl.Anim.SetBool("isMoving", true);
    }

}
