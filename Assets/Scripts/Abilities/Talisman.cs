using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : BaseAbility
{
    [SerializeField] protected float skillRange = 2f;
    [SerializeField] protected float pushForce = 5f;
   
    [SerializeField] protected LayerMask enemyLayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLayerMask();
    }
    protected virtual void LoadLayerMask()
    {
        if (enemyLayer != 0) return;
        enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
    }

    protected override void FixedUpdate()
    {
     //   Vector2 direction = -attackableObjCtrl.Model.right;
       // Debug.DrawRay(transform.parent.position, direction * skillRange, Color.red, 1f);
        base.FixedUpdate();
        this.RepelEnemies();
    }

    protected virtual void RepelEnemies()
    {
         if (!isReady) return;
        attackableObjCtrl.Anim.SetTrigger("Attack");
        FXSpawner.Instance.Spawn(FXSpawner.Talisman, transform.parent.position, Quaternion.identity);
        // Lấy hướng nhân vật đang đối mặt
        Vector2 direction = -attackableObjCtrl.Model.right;

        // Raycast kiểm tra va chạm
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.parent.position, direction, skillRange, enemyLayer);



        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider == null) continue;
            if(!hit.collider.isTrigger) continue;
            attackableObjCtrl.AttackableDamSender.SendDameSkill(hit.collider.transform);
             Vector2 pushDirection = direction.normalized * pushForce;
            DamageableObjCtrl damageableObjCtrl = hit.collider.transform.parent.GetComponent<DamageableObjCtrl>();
            if (damageableObjCtrl.Rb == null) continue;
            Debug.Log(damageableObjCtrl.name);
            damageableObjCtrl.Rb.AddForce(pushDirection, ForceMode2D.Impulse);
        }
    
        isReady = false;
        abilities.SetIsActive(false);

     
    }
    
}
