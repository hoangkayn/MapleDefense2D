using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHeroDamageReceiver : HouseDamReceiver
{
   
  
    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxHp = 120;
    }
   
    protected override void OnDead()
    {
        GameStateManager.Instance.GameOver();
    }

   
}
