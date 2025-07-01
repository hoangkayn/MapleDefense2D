using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : DamageObjAbstract
{
   [SerializeField] protected bool isFrozen;
   [SerializeField] protected float freezeTimer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        OffFreezing();
        freezeTimer = 0;
    }
    protected virtual void FixedUpdate()
    {
        if (!isFrozen) return;
        freezeTimer -= Time.fixedDeltaTime;
        if (freezeTimer > 0) return;
        this.OffFreezing();
    }
   public virtual void OffFreezing(){
    isFrozen = false;
damageableObjCtrl.ObjMovement.gameObject.SetActive(true);
        damageableObjCtrl.Anim.enabled = true;
         SpriteRenderer renderer = damageableObjCtrl.Model.GetComponent<SpriteRenderer>();
         renderer.color = Color.white;
   }
   public virtual void OnFreezing(float timer){
    isFrozen = true;
    freezeTimer = timer;
    damageableObjCtrl.ObjMovement.gameObject.SetActive(false);
        damageableObjCtrl.Anim.enabled = false;
         SpriteRenderer renderer = damageableObjCtrl.Model.GetComponent<SpriteRenderer>();
         renderer.color = Color.cyan;
   }
}
