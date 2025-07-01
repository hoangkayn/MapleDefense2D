using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class EnemyWaveDirector : BaseMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTimer = 3f;
    [SerializeField] protected int maxAliveEnemies = 1;
    [SerializeField] protected int spawnPerPrefab = 3;
   
    [SerializeField] protected EnemyCtrl enemyFist;
    protected Dictionary<string, int> spawnCounts = new();
    protected int currentPrefabIndex = 0;
    protected bool allSpawned = false;
    protected bool allowAutoSpawn = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    
    }
    

    protected virtual void LoadSpawnerCtrl()
    {
        if (spawnerCtrl != null) return;
        spawnerCtrl = GetComponent<SpawnerCtrl>();
    }

    protected virtual void FixedUpdate()
    {
        if (!allowAutoSpawn) return;
        if (allSpawned) return;
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if (LimitEnemy()) return;
        timer += Time.fixedDeltaTime;
        if (timer < delayTimer) return;

        timer = 0;
        List<Transform> prefabs = spawnerCtrl.Spawner.Prefabs;
        int checkedCount = 0;

        while (checkedCount < prefabs.Count)
        {
            Transform prefab = prefabs[currentPrefabIndex];
            string prefabName = prefab.name;

            if (!spawnCounts.ContainsKey(prefabName))
                spawnCounts[prefabName] = 0;

            if (spawnCounts[prefabName] < spawnPerPrefab)
            {
                spawnCounts[prefabName]++;
                Vector3 spawnPos = spawnerCtrl.SpawnPoint.position;
                spawnerCtrl.Spawner.Spawn(prefabName, spawnPos, Quaternion.identity);
                currentPrefabIndex = (currentPrefabIndex + 1) % prefabs.Count;
                return;
            }
            currentPrefabIndex = (currentPrefabIndex + 1) % prefabs.Count;
            checkedCount++;
        }
        allSpawned = true;
    }
    protected virtual bool LimitEnemy()
    {
        if (spawnerCtrl.Spawner.SpawnedCount >= maxAliveEnemies) return true;
        return false;
    }
    public virtual void SpawnFistEnemy()
    {
        Vector3 spawnPos = spawnerCtrl.SpawnPoint.position;
       Transform enemy = spawnerCtrl.Spawner.Spawn("Snail", spawnPos, Quaternion.identity);
        enemyFist = enemy.GetComponent<EnemyCtrl>();
//timelineEnemyBinder.BindEnemyToTimeline(enemy.gameObject);
    }
    public virtual void EnableMoveFirstEnemy()
    {
        enemyFist.ObjMovement.gameObject.SetActive(true);
    }
     public virtual void DisEnableMoveFirstEnemy()
    {
        enemyFist.ObjMovement.gameObject.SetActive(false);
    }
    public virtual void EnableAutoSpawn()
    {
        allowAutoSpawn = true;
    }
}
