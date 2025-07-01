using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BulletAbstract
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float rotSpeed = 100f;
    [SerializeField] protected float speed = 0.1f;

    protected virtual void FixedUpdate()
    {
        Flying();
    }
    protected virtual void Flying()
    {
        transform.parent.Translate(speed * Vector2.right);
    }
}
