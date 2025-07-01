using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Hero", menuName = "SO/Hero")]
public class HeroSO : DamageableObjSO
{
    public float spawnTime;
    public string heroId;
    public List<HeroLevelData> levelStats;
    public Sprite avtHero;
    public Sprite bgHero;
    public string skillDescription;
    public Sprite skillImage;
    public virtual int GetMaxHp(int level) => levelStats.Find(l => l.level == level)?.maxHp ?? 1;
    public virtual int GetMaxMp(int level) => levelStats.Find(l => l.level == level)?.maxMp ?? 1;
    public virtual int GetDame(int level) => levelStats.Find(l => l.level == level)?.dame ?? 1;
    public virtual int GetDameSkill(int level) => levelStats.Find(l => l.level == level)?.dameSkill ?? 1;
    public virtual int GetPricent(int level) => levelStats.Find(l => l.level == level)?.objPricent ?? 1;
    public virtual int GetUpgradeCost(int level) => levelStats.Find(l => l.level == level)?.upgradeCost ?? 1;
    public virtual int GetHpPercentHeal(int level) => levelStats.Find(l => l.level == level)?.hpPercentHeal ?? 1;
     public virtual int GetFreezeTime(int level) => levelStats.Find(l => l.level == level)?.freezeTime ?? 1;
}

