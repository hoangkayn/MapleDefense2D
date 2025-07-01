using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Savage : BaseAbility
{
    [SerializeField] protected float skillRange = 3f;
    [SerializeField] protected LayerMask enemyLayer; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }
    protected virtual void LoadLayerMask()
    {
        if (enemyLayer != 0) return;
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.WideAreaDamage();
    }
    protected virtual void WideAreaDamage()
    {
        if (!isReady) return;
         if (attackableObjCtrl.Anim != null)
        {
            attackableObjCtrl.Anim.SetTrigger("Attack");
        }
        FXSpawner.Instance.Spawn(FXSpawner.Savage, transform.parent.position, Quaternion.identity);
        // Lấy hướng nhân vật đang đối mặt
        Vector2 direction = -attackableObjCtrl.Model.right;

        // Raycast kiểm tra va chạm
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.parent.position, direction, skillRange, enemyLayer);



        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == null) continue;
            if (!hit.collider.isTrigger) continue;
            attackableObjCtrl.AttackableDamSender.SendDameSkill(hit.collider.transform);
        }
        isReady = false;
          abilities.SetIsActive(false);
    }
}
