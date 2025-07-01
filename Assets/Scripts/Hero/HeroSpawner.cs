using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    protected static HeroSpawner instance;
    public static HeroSpawner Instance => instance;
    [SerializeField] protected int pendingSpawnCount = 0;
    public int PendingSpawnCount => pendingSpawnCount;
    [SerializeField] protected HeroCtrl heroCutScene;
    public event Action OnHeroesSetupDone;
    [SerializeField] protected bool isSetupDone = false;
    public bool IsSetupDone => isSetupDone;

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
    protected override void Start()
    {
        base.Start();
         SetupHeroPrefabsFromGameData();
    }


    public void SetupHeroPrefabsFromGameData()
    {
        foreach (Transform prefab in this.prefabs)
        {
            HeroCtrl heroCtrl = prefab.GetComponent<HeroCtrl>();
            string heroId = heroCtrl.HeroSO.heroId;

            HeroSaveData saveData = GameDataManager.Instance.GetHeroData(heroId);
            heroCtrl.SetLevel(saveData.currentLevel);
        }
        OnHeroesSetupDone?.Invoke();
        isSetupDone = true;
    }
    public virtual HeroCtrl GetHeroCtrl(string id)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name != id) continue;
            HeroCtrl heroCtrl = prefab.GetComponent<HeroCtrl>();
            return heroCtrl;
        }
        return null;
    }
    public virtual void IncreasePendingSpawn()
    {
        pendingSpawnCount++;
    }
    public virtual void DecreasePendingSpawn()
    {
        pendingSpawnCount--;
    }
    protected virtual void AddHPBar(Transform hero)
    {
        Vector3 pos = hero.position;
        Transform hpBarObj = BarSpawner.Instance.Spawn(BarSpawner.HPBar, pos, Quaternion.identity);
        hpBarObj.localScale = new Vector3(1, 1, 1);
        TrackingHpBar hPBar = hpBarObj.GetComponent<TrackingHpBar>();
        hPBar.SetTarget(hero);
        DamageableObjCtrl damageableObjCtrl = hero.GetComponent<DamageableObjCtrl>();
        hPBar.SetDamageableObjCtrl(damageableObjCtrl);
    }
    protected virtual void AddMPBar(Transform hero)
    {
        Vector3 pos = hero.position;
        Transform prefabMpBar = BarSpawner.Instance.Spawn(BarSpawner.MPBar, pos, Quaternion.identity);
        MPBar mPBarHero = prefabMpBar.GetComponent<MPBar>();
        mPBarHero.SetTarget(hero);
        AttackableObjCtrl attackableObjCtrl = hero.GetComponent<AttackableObjCtrl>();
        mPBarHero.SetAttackableObjCtrl(attackableObjCtrl);
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform heroObj = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar(heroObj);
        ManaComponent manaComponent = heroObj.GetComponentInChildren<ManaComponent>();
        if (manaComponent == null) return heroObj;
        this.AddMPBar(heroObj);
        return heroObj;
    }
    public virtual void SpawnHeroCutScene(string name, Vector3 spawnPos, Quaternion rotation)
    {
        Transform hero = Spawn(name, spawnPos, rotation);
        heroCutScene = hero.GetComponent<HeroCtrl>();
    }
    public virtual void DisEnableMoveFirstHeroOnCutScene()
    {

        heroCutScene.ObjMovement.gameObject.SetActive(false);
        heroCutScene.Anim.SetBool("isMoving", false);
    }
    public virtual void EnableMoveFirstHeroOnCutScene()
    {

        heroCutScene.ObjMovement.gameObject.SetActive(true);
         heroCutScene.Anim.SetBool("isMoving", true);
    }
}
