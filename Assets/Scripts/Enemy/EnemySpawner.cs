using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    [SerializeField] protected int enemyDieCount;
    public int EnemyDieCount => enemyDieCount;
    public static event Action<int> OnEnemyDie;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected virtual void AddHPBar(Transform enemy)
    {
        Vector3 pos = enemy.position;
        Transform prefabHpBar = BarSpawner.Instance.Spawn(BarSpawner.HPBar, pos, Quaternion.identity);
        prefabHpBar.localScale = new Vector3(1, 1, 1);
        TrackingHpBar hPBarEnemy = prefabHpBar.GetComponent<TrackingHpBar>();
        hPBarEnemy.SetTarget(enemy);
        DamageableObjCtrl enemyCtrl = enemy.GetComponent<DamageableObjCtrl>();
        hPBarEnemy.SetDamageableObjCtrl(enemyCtrl);
    }
    protected virtual void AddMPBar(Transform enemy)
    {
        Vector3 pos = enemy.position;
        Transform prefabMpBar = BarSpawner.Instance.Spawn(BarSpawner.MPBar, pos, Quaternion.identity);
        MPBar mPBarEnemy = prefabMpBar.GetComponent<MPBar>();
       mPBarEnemy.SetTarget(enemy);
        AttackableObjCtrl attackableObjCtrl  = enemy.GetComponent<AttackableObjCtrl>();
        mPBarEnemy.SetAttackableObjCtrl(attackableObjCtrl);
    }

    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        this.enemyDieCount++;
        OnEnemyDie?.Invoke(enemyDieCount);
    }
    public override Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
       
        Transform newEnemy = base.Spawn(prefabName, spawnPos, rotation);
        this.AddHPBar(newEnemy);
        ManaComponent manaComponent = newEnemy.GetComponentInChildren<ManaComponent>();
        if (manaComponent == null) return newEnemy;
        this.AddMPBar(newEnemy);
        return newEnemy;
       
    }
    
}
