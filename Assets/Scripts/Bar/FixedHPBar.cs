using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedHPBar : HPBar
{
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageableObjCtrl();
    }
    protected virtual void LoadDamageableObjCtrl(){
        if(damageableObjCtrl != null) return;
        damageableObjCtrl = transform.parent.GetComponent<DamageableObjCtrl>();
    }
    protected override void Dead()
    {
        
        Destroy(gameObject);
    }
   
}
