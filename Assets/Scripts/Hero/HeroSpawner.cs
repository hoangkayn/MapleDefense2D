using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner
{
    protected static HeroSpawner instance;
    public static HeroSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if(instance!= null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
  
    protected virtual void AddHPBar(Transform obj)
    {
        Vector3 pos = transform.parent.position;
        Transform hpBarObj = HPBarSpawner.Instance.Spawn("HPBarHero",pos,Quaternion.identity);
        HPBar hPBar = hpBarObj.GetComponent<HPBar>();
        hPBar.FollowTarget.SetTarget(obj);
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform heroObj = base.Spawn(prefab, spawnPos, rotation);
        AddHPBar(heroObj);
        return heroObj;
    }

}
