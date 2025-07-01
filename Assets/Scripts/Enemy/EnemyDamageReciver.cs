using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : FixedStatDamReceiver
{
    protected override IEnumerator CoroutineDespawn()
    {
        yield return new WaitForSeconds(0.5f);
    EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override void DespawnObj(Transform obj)
    {
        EnemySpawner.Instance.Despawn(obj);
    }
}
