using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        PopupSpawner.Instance.Despawn(transform.parent);
        PopupManager.Instance.OnPopupDespawned();
    }
}
