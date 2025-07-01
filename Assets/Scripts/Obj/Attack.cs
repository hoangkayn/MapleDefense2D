using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : AttackableObjAbstract
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected bool isAttack = false;
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
     [SerializeField] protected float limitDis = 0.5f;
    public float LimitDis => limitDis;
    [SerializeField] protected LayerMask layerMask;
    public event Action OnAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }
    protected virtual void LoadAttackPoint()
    {
        if (attackPoint != null) return;
        attackPoint = transform.Find("AttackPoint");
    }
    protected virtual void FixedUpdate()
    {
        this.Attacking();
    }
    protected virtual void Update()
    {
        this.IsAttack();
    }
     
    public virtual bool IsAttack()
    {
        Transform target = attackableObjCtrl.ObjDetection.Target;
        if (target == null) return isAttack = false;
        float distance = Vector3.Distance(target.position, transform.parent.position);

        return this.isAttack = distance <= limitDis;
    }
    protected virtual void Attacking()
    {
        if (!this.IsAttack()) return;
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        OnAttack?.Invoke();
        if (attackableObjCtrl.Abilities != null && attackableObjCtrl.Abilities.SkillActiving) return;
        if (attackableObjCtrl.Anim != null)
        {
            attackableObjCtrl.Anim.SetTrigger("Attack");
        }
        attackableObjCtrl.AttackableDamSender.Send(attackableObjCtrl.ObjDetection.Target);
        AudioManager.Instance.PlayOneShot(attackableObjCtrl.DamageableObjSO.soundData.id);
    }

}
