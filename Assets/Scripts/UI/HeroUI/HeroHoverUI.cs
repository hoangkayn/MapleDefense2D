
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroHoverUI : BaseMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   
    [SerializeField] private HeroSO heroSO;
    public HeroSO HeroSO => heroSO;
    [SerializeField] protected HeroSaveData heroSaveData;
    public HeroSaveData HeroSaveData => heroSaveData;
    [SerializeField] protected HeroUpgradePanel heroUpgradePanel;
    [SerializeField] protected Image characterBg;
     [SerializeField] protected Image avtHero;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroUpgradePanel();
        this.LoadHeroSO();
        this.LoadCharacterBg();
        this.LoadAvtHero();
      
    }
    protected virtual void LoadCharacterBg()
    {
        if (characterBg != null) return;
        characterBg = transform.Find("CharacterBg/image").GetComponent<Image>();
         characterBg.sprite =  heroSO.bgHero;
    }
    protected virtual void LoadAvtHero()
    {
        if (avtHero != null) return;
        avtHero = transform.Find("Character/image").GetComponent<Image>();
        avtHero.sprite =  heroSO.avtHero;
    }
    protected override void Start()
    {
        base.Start();
        this.Setup();
    }
    protected virtual void LoadHeroSO()
    {
        if (heroSO != null) return;
        string id = transform.name.Replace("Slot_", "");
        heroSO = HeroDatabase.Instance.GetHeroSO(id);
    }
    protected virtual void Setup()
    {
        heroSaveData = GameDataManager.Instance.GetHeroData(heroSO.heroId);
      
        foreach (var component in GetComponentsInChildren<IHeroUIComponent>(true))
        {
            component.Setup(this);
        }
        
    }
    protected virtual void LoadHeroUpgradePanel()
    {
        if (heroUpgradePanel != null) return;
        heroUpgradePanel = transform.GetComponentInChildren<HeroUpgradePanel>(true);
        heroUpgradePanel.gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (heroSaveData.currentLevel >= heroSO.levelStats.Count) return;
        heroUpgradePanel.Show();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        heroUpgradePanel.Hide();
    }
}
