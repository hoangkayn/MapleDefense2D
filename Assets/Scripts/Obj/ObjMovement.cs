using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : AttackableObjAbstract
{

    [SerializeField] protected float limitDis;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected bool shouldMove = false;
    protected virtual void FixedUpdate()
    {
        this.Moving();
      
    }
    protected override void Start()
    {
        base.Start();
        SetLimitDis();
    }
    protected virtual void SetLimitDis() {
        if (attackableObjCtrl.ObjShooting != null)
        {
            limitDis = attackableObjCtrl.ObjShooting.LimitDis;
        }
        if (attackableObjCtrl.Attack != null) {
            limitDis = attackableObjCtrl.Attack.LimitDis;
        }
    }
    protected virtual void Moving()
    {
        Transform target = this.attackableObjCtrl.ObjDetection.Target;


        if (target == null) shouldMove = true;
        else
        {
            float distance = Vector3.Distance(transform.parent.position, target.position);
            if (distance > limitDis) shouldMove = true;
            else shouldMove = false;
        }
        attackableObjCtrl.Anim.SetBool("isMoving", shouldMove);
        if (shouldMove)
        {
            transform.parent.Translate(-attackableObjCtrl.Model.right * speed);
        }
    }
   

}
