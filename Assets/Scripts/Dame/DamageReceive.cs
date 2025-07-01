using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageReceive : BaseMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected float hp;
   
    [SerializeField] protected float maxHp;
   
    [SerializeField] protected bool isDead = false;
    

    public float HP => hp;
    public float MaxHp => maxHp;

    protected override void OnEnable()
    {
        Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
       
      
    }
    protected virtual void Reborn()
    {
       
        this.hp = maxHp;
        this.isDead = false;
    }

    public virtual void AddHP(float add)
    {
        if (this.isDead) return;

        this.hp += add;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void DeductHP(float deduct)
    {
        if (this.isDead) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
   
   
}
