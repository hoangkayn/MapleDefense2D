using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StarSO", menuName = "SO/StarSO")]
public class StarSO : ScriptableObject
{
    public List<RewardsByStars> stars;
    public virtual List<ItemReward>  GetRewardForStar(int index)
    {
        return stars[index - 1].itemRewards;
    }
}
