using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : BaseMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTimer = 7f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (spawnerCtrl != null) return;
        spawnerCtrl = transform.GetComponent<SpawnerCtrl>();
    }
    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
       
        timer += Time.fixedDeltaTime;
        if (timer < delayTimer) return;
        timer = 0;
        Vector3 pos = spawnerCtrl.SpawnPoint.position;
        
        Transform junkPrefab = spawnerCtrl.Spawner.RandomPrefab();
        this.spawnerCtrl.Spawner.Spawn(junkPrefab.name, pos, transform.rotation);
    }
}