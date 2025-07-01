using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class AttackDamReciver : DamageReceive
{
    [SerializeField] protected AttackableObjCtrl attackableObjCtrl;
    public AttackableObjCtrl AttackableObjCtrl => attackableObjCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackableObjCtrl();
    }
    protected virtual void LoadAttackableObjCtrl()
    {
        if (attackableObjCtrl != null) return;
        attackableObjCtrl = transform.parent.GetComponent<AttackableObjCtrl>();
    }
    protected override void OnDead()
    {
        attackableObjCtrl.Anim.SetTrigger("Die");
        StartCoroutine(CoroutineDespawn());
    }
    public override void DeductHP(float value)
    {
        base.DeductHP(value);
        if (attackableObjCtrl.ManaComponent == null) return;
        attackableObjCtrl.ManaComponent.AddMana(value);
    }
    protected virtual IEnumerator CoroutineDespawn()
    {
        yield return new WaitForSeconds(0.5f);
        DespawnObj(transform.parent);
    }
    protected abstract void DespawnObj(Transform obj);
}
