using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedStatMana : ManaComponent
{
       [SerializeField] protected FixedStatObjCtrl fixedStatObjCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFixedStatObjCtrl();
    }
    protected virtual void LoadFixedStatObjCtrl()
    {
        if (fixedStatObjCtrl != null) return;
        fixedStatObjCtrl = transform.parent.GetComponent<FixedStatObjCtrl>();
    }
    protected override void Setup()
    {
        maxMp = fixedStatObjCtrl.fixedStatSO.maxMp;
    }
}
