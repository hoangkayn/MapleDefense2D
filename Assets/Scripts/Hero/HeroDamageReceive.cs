using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageReceive : DamageReceive
{
    protected override void OnDead()
    {
        base.OnDead();
        StartCoroutine(DespawnObj());
    }
    protected virtual IEnumerator DespawnObj()
    {
        yield return new WaitForSeconds(0.5f);
        HeroSpawner.Instance.Despawn(transform.parent);
    }
}
