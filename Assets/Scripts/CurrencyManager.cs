using UnityEngine;
using System;

public class CurrencyManager : Singleton<CurrencyManager>
{
    [Header("Runtime Gold")]
    [SerializeField] private int gold;
    public int Gold => gold;
    [SerializeField] private int gem;
    public int Gem => gem;
    public static int MaxGold = 99999;
    public static int MaxGem = 99999;


      public static event Action<int> OnGoldChanged;
     public static event Action<int> OnGemChanged;

  
    public void LoadDataFromGameData(int gold,int gem)
    {
        this.gold = gold;
        this.gem = gem;
        OnGemChanged?.Invoke(gem);
         OnGoldChanged?.Invoke(gold);
    }

    public bool SpendGold(int amount)
    {
        if (gold < amount)
        {
            Debug.LogWarning("Không đủ gold!");
            return false;
        }

        gold -= amount;
        SyncGoldToGameData();
          OnGoldChanged?.Invoke(gold);
        return true;
    }
    public bool SpendGem(int amount)
    {
        if (gem < amount)
        {
            Debug.LogWarning("Không đủ Gem!");
            return false;
        }

        gem -= amount;
         
        SyncGemToGameData();
         OnGemChanged?.Invoke(gem);
        return true;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        if (gold > MaxGold) gold = MaxGold;
        SyncGoldToGameData();
         OnGoldChanged?.Invoke(gold);
    }
     public void AddGem(int amount)
    {
        gem += amount;
          if (gem > MaxGem) gem = MaxGem;
        SyncGemToGameData();
         OnGemChanged?.Invoke(gem);
    }

    public bool HasEnoughGold(int amount)
    {
        return gold >= amount;
    }

    private void SyncGoldToGameData()
    {
        GameDataManager.Instance.SetGold(gold);
      
    }
      private void SyncGemToGameData()
    {
        GameDataManager.Instance.SetGem(gem);
        
    }
}
