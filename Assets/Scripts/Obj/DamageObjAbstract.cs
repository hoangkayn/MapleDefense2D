using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjAbstract : BaseMonoBehaviour
{
    [SerializeField] protected DamageableObjCtrl damageableObjCtrl;
    public DamageableObjCtrl DamageableObjCtrl => damageableObjCtrl;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageableObjCtrl();
    }
    protected virtual void LoadDamageableObjCtrl()
    {
        if (damageableObjCtrl != null) return;
        damageableObjCtrl = transform.parent.GetComponent<DamageableObjCtrl>();
    }
}
