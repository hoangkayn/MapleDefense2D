using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtEneneyKillCount : BaseText
{
    protected override void Start()
    {
        base.Start();
        EnemySpawner.OnEnemyDie += UpdateKillCount;
    }
    protected virtual void DisOnEnable()
    {
        EnemySpawner.OnEnemyDie -= UpdateKillCount;
    }
    protected virtual void UpdateKillCount(int count)
    {
        this.text.text = count.ToString();
    }
}
