using UnityEngine;

public  class ObjDetection : BaseMonoBehaviour
{ 
     [SerializeField] private float range = 10f;
    [SerializeField] protected Transform target;
    public Transform Target => target;
    [SerializeField] protected LayerMask targetLayer;
    [SerializeField] protected float findTimer;
    [SerializeField] protected float findInterval = 0.5f;


    protected virtual void FixedUpdate()
    {
        findTimer += Time.fixedDeltaTime;
        if (findTimer < findInterval) return;
        findTimer = 0;
        this.target = FindNearestTarget();
    }

    public virtual Transform FindNearestTarget()
    {
       
       Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, targetLayer);
        float minDist = float.MaxValue;
        Transform nearest = null;
        foreach (var hit in hits)
        {
            if (!hit.isTrigger) continue;
            DamageReceive damageReceive = hit.GetComponent<DamageReceive>();
            if (damageReceive == null || damageReceive.IsDead()) continue;
          

            float dist = Vector2.Distance(transform.position, hit.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = hit.transform;
            }
        }
        return nearest;
    
    }
}
