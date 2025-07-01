using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionFly {
    None,
    Up,
    Down,
    Right,
    Left
}
public class FlyDirection : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected DirectionFly directionFly;

    protected virtual void FixedUpdate()
    {
        Flying();
    }
    protected virtual void Flying()
    {
        if (directionFly == DirectionFly.Up) transform.parent.Translate(speed * Vector2.up);
        if (directionFly == DirectionFly.Down) transform.parent.Translate(speed * Vector2.down);
        if (directionFly == DirectionFly.Right) transform.parent.Translate(speed * Vector2.right);
           if (directionFly == DirectionFly.Left) transform.parent.Translate(speed * Vector2.left);
    }
}
