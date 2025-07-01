
using UnityEngine;


public class FollowTarget : BaseMonoBehaviour
{
    [SerializeField] protected Transform targetPos;

    [SerializeField] protected float speed = 1f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        if (targetPos == null) return;
        Vector3 newPos = Vector3.Lerp(transform.position, targetPos.position, speed);
        transform.position = newPos;
    }
    public virtual void SetTarget(Transform obj)
    {
        targetPos = obj;
    }
}
