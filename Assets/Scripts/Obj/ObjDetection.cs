using UnityEngine;

public abstract class ObjDetection : ShootableObjAbstract
{ 
    [SerializeField] protected Transform target;
    public Transform Target => target;

    protected virtual void FixedUpdate()
    {
         if (target != null)
        {
            DamageReceive damageReceive = target.GetComponentInChildren<DamageReceive>();
            if (!damageReceive.IsDead()) return;
        }
        FindNearestTarget();
       
    }

    public virtual void FindNearestTarget()
    {
       
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetName()); 
        float minDistance = Mathf.Infinity;
        Transform closest = null;
        foreach (GameObject target in targets)
        {

            float distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = target.transform;
            }
        }

        this.target = closest;
    
    }
    protected abstract string TargetName();
}
