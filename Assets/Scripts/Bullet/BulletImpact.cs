using UnityEngine;

[ RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadCollider()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.radius = 0.12f;
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.offset = new Vector2(0.97f,0);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.transform.parent == bulletCtrl.Shooter) return;
        if (collision.transform != bulletCtrl.Target) return;
        if (collision.transform == null) return;
        bulletCtrl.BulletDamSender.Send(collision.transform);
        bulletCtrl.BulletDespawn.DespawnObject();
    }
}