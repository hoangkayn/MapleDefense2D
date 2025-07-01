using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LevelByCoin : Level
{
    protected static LevelByCoin instance;
    public static LevelByCoin Instance => instance;
    [SerializeField] protected UpgradeLvSO upgradeLvSO;
    public UpgradeLvSO UpgradeLvSO => upgradeLvSO;
    public static event Action OnLevelUp;

    protected override void Awake()
    {
        base.Awake();
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeLvSO();
    }
    protected virtual void LoadUpgradeLvSO()
    {
        if (upgradeLvSO != null) return;
        string resPath = "SO/UpgradeLv/UpgradeLv";
        this.upgradeLvSO = Resources.Load<UpgradeLvSO>(resPath);
    }
    public override void LevelUp()
    {
        int upgradeCost = upgradeLvSO.lobbyLevelDatas[levelCurrent + 1].upgradeCost;
        if (!CoinManager.Instance.SpendCoins(upgradeCost)) return;
        base.LevelUp();
        OnLevelUp?.Invoke();
    }
}
