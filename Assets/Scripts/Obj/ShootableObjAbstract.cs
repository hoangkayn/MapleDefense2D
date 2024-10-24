using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjAbstract : BaseMonoBehaviour
{
    [SerializeField] protected ShootableObjCtrl shootableObjCtrl;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjMoveableCtrl();
    }
    protected virtual void LoadObjMoveableCtrl()
    {
        if (shootableObjCtrl != null) return;
        shootableObjCtrl = transform.parent.GetComponent<ShootableObjCtrl>();
    }
}
