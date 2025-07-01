
using UnityEngine;

public class GodPunch : BaseAbility
{ 
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Attack();
    }
    protected virtual void Attack()
    {
        if (!isReady) return;
        if (attackableObjCtrl.Anim != null)
        {
            attackableObjCtrl.Anim.SetTrigger("Attack");
        }
        FXSpawner.Instance.Spawn(FXSpawner.GodPunch, transform.parent.position, Quaternion.identity);
        attackableObjCtrl.AttackableDamSender.SendDameSkill(attackableObjCtrl.ObjDetection.Target);
        AudioManager.Instance.PlayOneShot(attackableObjCtrl.DamageableObjSO.soundData.id);
         isReady = false;
          abilities.SetIsActive(false);
    }
}
