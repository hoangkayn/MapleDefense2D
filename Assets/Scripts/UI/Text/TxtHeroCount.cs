using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtHeroCount : BaseText
{
     protected virtual void FixedUpdate()
    {
        int currentHero = HeroSpawner.Instance.SpawnedCount;
        int curretnLv = LevelByCoin.Instance.LevelCurrent;
        int heroCount = LevelByCoin.Instance.UpgradeLvSO.lobbyLevelDatas[curretnLv].heroCount;
        this.text.text = "Hero On Lobby: " + currentHero+ "/"+heroCount;
    }
}
