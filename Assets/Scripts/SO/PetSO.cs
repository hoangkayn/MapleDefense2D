
using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
public enum PetRank
{
    Normal,
    Rare,
    Legendary
}
public enum SpecialReward
{
    HPTower
}
[Serializable]
public class ItemBonus {
    public RewardSO rewardSO;
    public int bonusMultiplier;
 }
 [Serializable]
public class SpecialBonus
{
    public SpecialReward specialReward;
    public int bonusMultiplier;
}
[CreateAssetMenu(fileName = "Pet", menuName = "SO/Pet")]
public class PetSO : ScriptableObject
{
    public string idName;
    public int price;
    public Sprite iconPet;
    public PetRank petRank;
    public List<ItemBonus> itemBonus;
    public List<SpecialBonus> specialBonus;
    public AnimatorController animatorController;
    public string description;
}
