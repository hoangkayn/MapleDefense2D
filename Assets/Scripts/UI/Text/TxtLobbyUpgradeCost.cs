using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLobbyUpgradeCost : BaseText
{
    
    protected virtual void FixedUpdate()
    {
        int levelCurrent = LevelByCoin.Instance.LevelCurrent;
        int upgradeCost = LevelByCoin.Instance.UpgradeLvSO.lobbyLevelDatas[levelCurrent + 1].upgradeCost;
        this.text.text = upgradeCost.ToString();
    }
}
