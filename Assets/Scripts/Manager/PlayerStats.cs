using System;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] protected PlayerSaveData playerSaveData;
    public PlayerSaveData PlayerSaveData => playerSaveData;
    [SerializeField] private ExpTableSO expTable;
    public ExpTableSO ExpTableSO => expTable;
    
    public static event Action<int> OnLevelChanged;
    public static event Action<int,int> OnExpChanged;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExpTableSO();
    }
    protected virtual void LoadExpTableSO()
    {
        if (expTable != null) return;
        string resPath = "SO/ExpTable/ExpTableSO";
        expTable = Resources.Load<ExpTableSO>(resPath);
    }
    public void LoadDataFromGameData(PlayerSaveData player)
    {
 playerSaveData = player;
       
        OnLevelChanged?.Invoke(playerSaveData.playerLevel);
         OnExpChanged?.Invoke(playerSaveData.playerExp,expTable.GetExpForLevel(playerSaveData.playerLevel));
    }

    public void AddExp(int amount)
    {
        playerSaveData.playerExp += amount;
        while (playerSaveData.playerExp >= expTable.GetExpForLevel(playerSaveData.playerLevel))
        {
            if (playerSaveData.playerLevel == expTable.expPerLevel.Count) break;
            playerSaveData.playerExp -= expTable.GetExpForLevel(playerSaveData.playerLevel);
            playerSaveData.playerExp++;
            LevelUp();
        }

        OnExpChanged?.Invoke(playerSaveData.playerExp, expTable.GetExpForLevel(playerSaveData.playerLevel));
        SyncPlayerToGameData();
    }
    protected virtual void LevelUp()
    {
        playerSaveData.playerLevel++;
        OnLevelChanged?.Invoke(playerSaveData.playerLevel);
           SyncPlayerToGameData();
    }
 private void SyncPlayerToGameData()
    {
        GameDataManager.Instance.SetPlayer(playerSaveData);

    }
}
