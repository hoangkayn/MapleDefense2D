using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackableObjCtrl : DamageableObjCtrl
{
    [SerializeField] protected AttackableDamSender attackableDamSender;
    public AttackableDamSender AttackableDamSender => attackableDamSender;
     [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;
      [SerializeField] protected Attack attack;
    public Attack Attack => attack;
    [SerializeField] protected ManaComponent manaComponent;
    public ManaComponent ManaComponent => manaComponent;
     [SerializeField] protected Abilities abilities;
    public Abilities  Abilities=> abilities;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackableDamSender();
        this.LoadManaComponent();
        this.LoadObjShooting();
        this.LoadAttack();
        this.LoadAbilities();
    }
    protected virtual void LoadAttack()
    {
        if (attack != null) return;
        attack = transform.GetComponentInChildren<Attack>();
    }
     protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = transform.GetComponentInChildren<Abilities>();
    }
    protected virtual void LoadObjShooting()
    {
        if (objShooting != null) return;
        objShooting = transform.GetComponentInChildren<ObjShooting>();
    }
    protected virtual void LoadAttackableDamSender()
    {
        if (attackableDamSender != null) return;
        attackableDamSender = transform.GetComponentInChildren<AttackableDamSender>();
    }
     protected virtual void LoadManaComponent()
    {
        if (manaComponent != null) return;
        manaComponent = transform.GetComponentInChildren<ManaComponent>();
    }
}
