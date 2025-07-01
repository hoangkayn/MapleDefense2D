
using UnityEngine;

public class CaaracterInfoUI : BaseMonoBehaviour, IHeroUIComponent
{
    [SerializeField] protected HeroHoverUI heroHoverUI;
    [SerializeField] protected TxtLvHero txtLvUpHero;
    [SerializeField] protected TxtNameHero txtNameHero;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTxtLvUpHero();
        this.LoadTxtNameHero();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        GameDataManager.OnHeroLevelUp += HandleHeroLevelUp;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        GameDataManager.OnHeroLevelUp -= HandleHeroLevelUp;
    }
    private void HandleHeroLevelUp(HeroSaveData heroSaveData)
    {
        if (this.heroHoverUI.HeroSaveData != heroSaveData) return;

        Refresh();
    }
    protected virtual void LoadTxtLvUpHero()
    {
        if (txtLvUpHero != null) return;
        txtLvUpHero = transform.GetComponentInChildren<TxtLvHero>();
    }
    protected virtual void LoadTxtNameHero()
    {
        if (txtNameHero != null) return;
        txtNameHero = transform.GetComponentInChildren<TxtNameHero>();
    }
    public void Setup(HeroHoverUI heroHoverUI)
    {
        this.heroHoverUI = heroHoverUI;
        Refresh();
    }
    private void Refresh()
    {
        txtLvUpHero.Refresh(heroHoverUI);
        txtNameHero.Refresh(heroHoverUI);
    }
}
