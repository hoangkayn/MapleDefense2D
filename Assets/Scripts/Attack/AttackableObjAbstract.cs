using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObjAbstract : BaseMonoBehaviour
{
    [SerializeField] protected AttackableObjCtrl attackableObjCtrl;
    public AttackableObjCtrl AttackableObjCtrl => attackableObjCtrl;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackableObjCtrl();
    }
    protected virtual void LoadAttackableObjCtrl()
    {
        if (attackableObjCtrl != null) return;
        attackableObjCtrl = transform.parent.GetComponent<AttackableObjCtrl>();
    }
}
