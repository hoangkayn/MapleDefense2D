using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : SpawnerCtrl
{
    protected override void LoadSpawnPoint()
    {
        this.spawnPoint = GameObject.Find("HouseEnemy").transform.Find("SpawnPoint");
    }
}
