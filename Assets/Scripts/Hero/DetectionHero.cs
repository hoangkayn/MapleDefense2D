using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionHero : ObjDetection
{
    protected override string TargetName()
    {
       return ObjType.Enemy.ToString();
    }
}
