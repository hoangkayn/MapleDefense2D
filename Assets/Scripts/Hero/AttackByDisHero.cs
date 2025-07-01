using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByDisHero : Attack
{
      protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }
    protected virtual void LoadLayerMask(){
        if(layerMask != 0) return;
        layerMask = LayerMask.GetMask("Enemy");
    }
}
