
using UnityEngine;

public class TowerHeroDamageReceive : TowerDamReceiver
{
    protected override void Reborn()
    {
        this.maxHp = fixedStatObjCtrl.fixedStatSO.GetMaxHp();
        PetSO petSO = PetDatabase.Instance.GetPetSO(GameDataManager.Instance.GetSelectedPetId());
        foreach (SpecialBonus specialBonus in petSO.specialBonus)
        {
            if (specialBonus.specialReward != SpecialReward.HPTower) continue;
            int hpBonus = Mathf.RoundToInt(specialBonus.bonusMultiplier * maxHp);
            maxHp += hpBonus;
        }
        hp = maxHp;
    }
    protected override void OnEnable()
    {

    }
    protected override void Start()
    {
        base.Start();
        Reborn();
    }
}
