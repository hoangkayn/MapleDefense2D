using System.Collections;
using UnityEngine;

public class FreezeBulletImpact : BulletImpart
{
  [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected float freezeDuration;
  protected override void LoadComponents()
  {
    base.LoadComponents();
    this.LoadEnemyLayer();
    }
  protected virtual void LoadEnemyLayer()
  {
        if (enemyLayer != 0) return;
        enemyLayer = LayerMask.GetMask("Enemy");
    }
  public virtual void SetFreezeDuration(int value)
  {
    freezeDuration = value;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
  {
    if ((enemyLayer.value & (1 << collision.gameObject.layer)) == 0) return;
    bulletCtrl.BulletDamSender.Send(collision.transform);
    Freezable freezable = collision.transform.parent.GetComponentInChildren<Freezable>();
    if (freezable == null) return;
    freezable.OnFreezing(freezeDuration);


  }

    
}
