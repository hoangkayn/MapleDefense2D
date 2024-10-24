using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemy : ObjDetection
{
    protected override string TargetName()
    {
        return ObjType.Hero.ToString();
    }

   
}
