using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawn
{
    [Header("DespawnByTime")]
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTime = 2f;
    public float DelayTime => delayTime;

   

    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer < delayTime) return false;
        timer = 0;
        return true;
    }
}
