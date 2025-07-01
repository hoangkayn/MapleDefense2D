using UnityEngine;
using System.Collections.Generic;

public class GameResultHandler : Singleton<GameResultHandler>
{
    [SerializeField] protected StarSO starSO;
 protected override void LoadComponents()
    {
        base.LoadComponents();
      
        LoadStarSO();
     
    }
    protected virtual void LoadStarSO()
    {
        if (starSO != null) return;
         string resPath = "SO/Star/Star";
        starSO = Resources.Load<StarSO>(resPath);
    }
   
    protected override void OnEnable()
    {
        GameStateManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    protected override void OnDisable()
    {
        GameStateManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    protected virtual void HandleGameStateChanged(eStateGame state)
    {
        if (state == eStateGame.WIN)
        {
            ApplyRewards();
        }
    }
    protected virtual void ApplyRewards()
    {
        int starCount = GetStarCount();
        List<ItemReward> baseRewards = starSO.GetRewardForStar(starCount);
        List<ItemReward> bonusRewards = GetBonusRewards(baseRewards);

        // Gộp base + bonus lại thành 1 danh sách tổng
        List<ItemReward> totalRewards = MergeRewards(baseRewards, bonusRewards);

        foreach (ItemReward reward in totalRewards)
        {
            AddToCurrency(reward);
        }
    }
    protected virtual int GetStarGamePlay()
    {
    return TimeManager.Instance.GetStarRating();
   }
    protected virtual int GetStartCutScene()
    {
        return starSO.stars.Count;
   }
   protected virtual bool IsCutScene()
{
    return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("CutScene Instructor");
}

public virtual int GetStarCount()
{
    return IsCutScene() ? GetStartCutScene() : GetStarGamePlay();
}


    protected virtual List<ItemReward> GetBonusRewards(List<ItemReward> baseRewards)
    {
        List<ItemReward> bonuses = new();
        string selectedPetId = GameDataManager.Instance.GetSelectedPetId();
        if (string.IsNullOrEmpty(selectedPetId)) return bonuses;

        PetSO petSO = PetDatabase.Instance.GetPetSO(selectedPetId);

        foreach (ItemReward reward in baseRewards)
        {
            foreach (ItemBonus itemBonus in petSO.itemBonus)
            {
                if (itemBonus.rewardSO != reward.rewardSO) continue;

                bonuses.Add(new ItemReward
                {
                    rewardSO = reward.rewardSO,
                    count = itemBonus.bonusMultiplier * reward.count
                });
            }
        }

        return bonuses;
    }

    protected virtual List<ItemReward> MergeRewards(List<ItemReward> list1, List<ItemReward> list2)
    {
        Dictionary<RewardSO, int> rewardMap = new();

        void AddToMap(List<ItemReward> list)
        {
            foreach (var r in list)
            {
                if (rewardMap.ContainsKey(r.rewardSO))
                    rewardMap[r.rewardSO] += r.count;
                else
                    rewardMap[r.rewardSO] = r.count;
            }
        }

        AddToMap(list1);
        AddToMap(list2);

        List<ItemReward> merged = new();
        foreach (var kvp in rewardMap)
        {
            merged.Add(new ItemReward
            {
                rewardSO = kvp.Key,
                count = kvp.Value
            });
        }

        return merged;
    }

    protected virtual void AddToCurrency(ItemReward reward)
    {
        RewardType rewardType = reward.rewardSO.rewardType;

        if (rewardType == RewardType.Diamond)
            CurrencyManager.Instance.AddGem(reward.count);
        else if (rewardType == RewardType.Gold)
            CurrencyManager.Instance.AddGold(reward.count);
        else if (rewardType == RewardType.Exp)
        {
            PlayerStats.Instance.AddExp(reward.count);
            }
       
    }
}
