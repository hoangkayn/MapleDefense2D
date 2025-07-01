using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuyHero : BaseButton
{
    [SerializeField] protected Image panelTime;
    [SerializeField] protected float timer;
    [SerializeField] protected bool canSpawn = true;
    [SerializeField] protected bool isMockMode = false;

    [SerializeField] protected HeroSO heroSO;
    public HeroSO HeroSO => heroSO;
    public event Action OnHeroBoughtFirstCutScene;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPanelTime();
        this.LoadHeroSO();
    }
    protected virtual void LoadHeroSO()
    {
        if (heroSO != null) return;
        string id = transform.name.Replace("BtnSelect_", "");
        heroSO = HeroDatabase.Instance.GetHeroSO(id);
    }
    protected virtual void LoadPanelTime()
    {
        if (panelTime != null) return;
        panelTime = transform.Find("PanelTime").GetComponent<Image>();
    }
    protected override void OnClick()
    {
    
        if (!canSpawn) return;
        StartCoroutine(SpawnHero());
    }
    protected virtual bool BuyHero(HeroSO heroSO)
    {
        HeroCtrl heroCtrl = HeroSpawner.Instance.GetHeroCtrl(heroSO.heroId);
        int heroPricent = heroSO.GetPricent(heroCtrl.CurrentLevel);
        if (heroPricent > CoinManager.Instance.CurrentCoin) return false;
        int heroCount = LevelByCoin.Instance.UpgradeLvSO.lobbyLevelDatas[LevelByCoin.Instance.LevelCurrent].heroCount;
        if (HeroSpawner.Instance.SpawnedCount + HeroSpawner.Instance.PendingSpawnCount >= heroCount) return false;

         CoinManager.Instance.SpendCoins(heroPricent);
        HeroSpawner.Instance.IncreasePendingSpawn();
        return true;
    }
    protected virtual IEnumerator SpawnHero()
    {
        if (!BuyHero(heroSO)) yield break;
        canSpawn = false;
        float spawnTime = heroSO.spawnTime;
        panelTime.fillAmount = 1f;

        while (timer < spawnTime)
        {
            timer += Time.deltaTime;
            panelTime.fillAmount = 1 - (timer / spawnTime);
            yield return null;

        }
        timer = 0;
        panelTime.fillAmount = 0;
        if (isMockMode)
        {
            OnHeroBoughtFirstCutScene?.Invoke();
            HeroSpawner.Instance.SpawnHeroCutScene(heroSO.heroId, GameCtrl.Instance.SpawnPointHero.position, Quaternion.identity);
        }
        else
        {
              HeroSpawner.Instance.Spawn(heroSO.heroId, GameCtrl.Instance.SpawnPointHero.position, Quaternion.identity);
        }
      
        HeroSpawner.Instance.DecreasePendingSpawn();
        canSpawn = true;
      
    }
    public virtual void EnableMockMode()
    {
        isMockMode = true;
    }
     public virtual void DisEnableMockMode()
    {
        isMockMode = false;
    }
   
}
