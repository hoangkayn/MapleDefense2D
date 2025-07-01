using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HPBar : Bar
{
    [SerializeField] protected DamageableObjCtrl damageableObjCtrl;
    public DamageableObjCtrl DamageableObjCtrl => damageableObjCtrl;

    protected override void Showing()
    {
        if (damageableObjCtrl == null) return;
        bool isDead = damageableObjCtrl.DamageReceive.IsDead();
        if (isDead)
        {
            this.Dead();
            return;
        }
        if (damageableObjCtrl == null) return;
        float hp = damageableObjCtrl.DamageReceive.HP;
        float maxHp = damageableObjCtrl.DamageReceive.MaxHp;
        this.slider.SetValue(hp);
        this.slider.SetMaxValue(maxHp);
    }

    protected abstract void Dead();
}
