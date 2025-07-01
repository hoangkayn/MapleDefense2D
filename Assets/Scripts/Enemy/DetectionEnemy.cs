using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemy : ObjDetection
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMark();
    }
    protected virtual void LoadLayerMark()
    {
        if (targetLayer != 0) return;
        targetLayer = LayerMask.GetMask("Hero");
    }

   
}
