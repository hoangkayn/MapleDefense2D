using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : BaseMonoBehaviour
{
    public virtual void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
