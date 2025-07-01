using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseAbility : BaseMonoBehaviour
{
    [SerializeField] protected Abilities abilities;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeDelay = 0f;
    [SerializeField] protected bool isReady = false;
    [SerializeField] protected AttackableObjCtrl attackableObjCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
        this.LoadAttackableObjCtrl();
    }
    protected virtual void LoadAttackableObjCtrl()
    {
        if (attackableObjCtrl != null) return;
        attackableObjCtrl = transform.parent.parent.GetComponent<AttackableObjCtrl>();
    }
    protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = transform.parent.GetComponent<Abilities>();
    }
    protected virtual void FixedUpdate()
    {
        //this.Timing();

    }
    /*  protected virtual void Timing()
      {
          if (isReady) return;
          timer += Time.fixedDeltaTime;
          if (timer < timeDelay) return;
          timer = 0;
          this.isReady = true;
      }*/
    public virtual void Active()
    {
        isReady = true;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        isReady = false;
    }
}
