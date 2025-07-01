using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCtrl : BaseMonoBehaviour
{
    protected static GameCtrl instance;
    public static GameCtrl Instance => instance;
    [SerializeField] protected Transform spawnPointHero;
    public Transform SpawnPointHero => spawnPointHero;

    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPointHero();
     
    }
    protected virtual void LoadSpawnPointHero()
    {
        if (spawnPointHero != null) return;
        spawnPointHero = GameObject.Find("SpawnPointHero").transform;
    }
   
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
}
