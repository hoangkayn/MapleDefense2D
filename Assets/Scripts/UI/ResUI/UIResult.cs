using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResult : UIMenu
{
    [SerializeField] protected Stars stars;
  
    [SerializeField] protected StarSO starSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadStars();
        LoadStarSO();
     
    }
    protected virtual void LoadStarSO()
    {
        if (starSO != null) return;
         string resPath = "SO/Star/Star";
        starSO = Resources.Load<StarSO>(resPath);
    }
   
   
    protected virtual void LoadStars()
    {
        if (stars != null) return;
        stars = transform.GetComponentInChildren<Stars>();
    }
    public override void Show()
    {
        base.Show();
        int startCount = GameResultHandler.Instance.GetStarCount();
        stars.DisplayStars(startCount);
        SpawnRewards(startCount);
    }
    protected virtual void SpawnRewards(int starCount)
    {
        List<ItemReward> itemRewards = starSO.GetRewardForStar(starCount);

        foreach (var itemReward in itemRewards)
        {
            UIItemSpawner.Instance.SpawnItemStar(itemReward);
            ApplyPetBonus(itemReward);
        }
    }
protected virtual void ApplyPetBonus(ItemReward rewardStar)
{
    string selectedPetId = GameDataManager.Instance.GetSelectedPetId();
     if (selectedPetId == null) return;
    PetSO petSO = PetDatabase.Instance.GetPetSO(selectedPetId);

        foreach (ItemBonus itemBonus in petSO.itemBonus)
        {
            if (itemBonus.rewardSO != rewardStar.rewardSO) continue;
            ItemReward bonus = new ItemReward()
            {
                rewardSO = rewardStar.rewardSO,
                count = itemBonus.bonusMultiplier * rewardStar.count
            };
      UIItemBonusSpawner.Instance.SpawnItemBonus(bonus);
    }
  
}
}
