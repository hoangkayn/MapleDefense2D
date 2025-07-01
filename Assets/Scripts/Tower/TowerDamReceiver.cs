using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamReceiver : FixedStatDamReceiver
{
    protected override void DespawnObj(Transform obj)
    {
         Destroy(obj.gameObject);
    }
}
