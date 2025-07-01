using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroSaveData
{
    public string heroId;
    public int currentLevel;
    public HeroSaveData(string heroId, int currentLevel)
    {
        this.heroId = heroId;
        this.currentLevel = currentLevel;
    }
}
[System.Serializable]
public class PlayerSaveData
{
    public string playerName;
    public int playerLevel;
    public int playerExp;
    public PlayerSaveData(string playerName, int playerLevel, int playerExp)
    {
        this.playerName = playerName;
        this.playerLevel = playerLevel;
        this.playerExp = playerExp;
    }
}
[System.Serializable]
public class PetSaveData
{
     public string petId;

    public PetSaveData(string petId)
    {
        this.petId = petId;
    }
}
public class GameSaveData
{
    public List<HeroSaveData> heroes = new();
    public List<PetSaveData> pets = new();
    public PlayerSaveData player;

    public int gold;
    public int gem;
    public string selectedPetId;
}
public class GameDataManager : Singleton<GameDataManager>
{

    private int gold;
    public int Gold => gold;
    private int gem;
    public int Gem => gem;
    private List<HeroSaveData> heroList = new();
    public List<HeroSaveData> HeroList => heroList;
    private List<PetSaveData> petList = new();
    public List<PetSaveData> PetList => petList;
    private string selectedPetId;
    private PlayerSaveData player;
    public PlayerSaveData Player => player;

    public static event Action<HeroSaveData> OnHeroLevelUp;
    public static event Action BtnSelectPet;
    protected override void Awake()
    {
        base.Start();
        LoadGame();
    }
    public bool IsPetPurchased(string id)
    {
        foreach (PetSaveData pet in petList)
        {
            if (id == pet.petId) return true;
        }
        return false;
    }
    public string GetSelectedPetId()
    {
        return selectedPetId;
    }
    public bool IsSelected(string id)
    {
        return id == selectedPetId;
    }


    // Tạo dữ liệu mặc định (khi new game)
    public void CreateNewGameDefault()
    {
        heroList.Clear();
        petList.Clear();
        Debug.Log("creat new game");
        heroList.Add(new HeroSaveData("Magician", 1));
        heroList.Add(new HeroSaveData("Kain", 1));
        heroList.Add(new HeroSaveData("Kinesis", 1));
        heroList.Add(new HeroSaveData("Lumious", 1));
        heroList.Add(new HeroSaveData("Pathfider", 1));
        gold = 1000;
        gem = 1000;
        SaveGame();
    }
    public virtual void SetGold(int value)
    {
        gold = value;
        SaveGame();
    }
    public virtual void SetGem(int value)
    {
        gem = value;
        SaveGame();
    }
    public virtual void SetPlayer(PlayerSaveData playerSaveData)
    {
        player = playerSaveData;
        SaveGame();
    }
    public virtual void SetSelectedPetId(string id)
    {
        selectedPetId = id;
        SaveGame();
    }

    public void SaveGame()
    {
        GameSaveData saveData = BuildSaveData();
        SaveSystem.SaveGame(saveData);
    }
    public void LoadGame()
    {
        GameSaveData loadedData = SaveSystem.LoadGame();
        if (loadedData == null)
        {
            Debug.Log("Không tìm thấy dữ liệu. Tạo game mới.");
            CreateNewGameDefault();
            return;
        }
        ApplySaveData(loadedData);
        ApplyRuntimeSystems();
    }
    public virtual void ApplyRuntimeSystems()
    {
        CurrencyManager.Instance.LoadDataFromGameData(gold, gem);
        PlayerStats.Instance.LoadDataFromGameData(player);
    }
    private GameSaveData BuildSaveData()
    {
        return new GameSaveData
        {
            heroes = new List<HeroSaveData>(heroList),
            pets = new List<PetSaveData>(petList),
            gold = this.Gold,
            gem = this.Gem,
            selectedPetId = this.selectedPetId,
            player = new PlayerSaveData(player.playerName, player.playerLevel, player.playerExp),

        };
    }
    // Ghi dữ liệu load được vào runtime
    private void ApplySaveData(GameSaveData saveData)
    {

        this.heroList = new List<HeroSaveData>(saveData.heroes);
        this.petList = new List<PetSaveData>(saveData.pets);
        this.gold = saveData.gold;
        this.gem = saveData.gem;
        this.selectedPetId = saveData.selectedPetId;
        this.player = saveData.player;

    }

    // Tăng cấp hero
    public void LevelUpHero(HeroSaveData heroSaveData)
    {
        heroSaveData.currentLevel++;
        OnHeroLevelUp?.Invoke(heroSaveData);
        SaveGame();
    }
    public void BuyPet(string petId)
    {
        petList.Add(new PetSaveData(petId));
        SaveGame();
    }
    public void SelectPet(string petId)
    {
        if (!IsPetPurchased(petId)) return;
        selectedPetId = petId;
        BtnSelectPet?.Invoke();
        SaveGame();
    }
    public HeroSaveData GetHeroData(string heroId)
    {
        return heroList.Find(h => h.heroId == heroId);
    }
    public PetSaveData GetPetSaveData(string petId)
    {
        return petList.Find(h => h.petId == petId);
    }
    public virtual void AddPetFirst(string id)
    {
        petList.Add(new PetSaveData(id));
        SetSelectedPetId(id);
    }
}
