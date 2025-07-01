using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HouseDamReceiver : DamageReceive
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void LoadCollider()
    {
        base.LoadCollider();
         this.circleCollider2D.radius = 0.4f;
        this.circleCollider2D.offset =new Vector2(0, 0.21f);
    }
   
  
}
