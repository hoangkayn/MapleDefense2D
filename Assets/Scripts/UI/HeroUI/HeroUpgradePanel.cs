using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class HeroUpgradePanel : BaseMonoBehaviour, IHeroUIComponent
{

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI mpText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] protected TextMeshProUGUI heroSkillDescText;
    [SerializeField] protected Image skillImage;
    [SerializeField] protected TextMeshProUGUI nameHeroText;
    [SerializeField] private HeroHoverUI heroHoverUI;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHpText();
        this.LoadMpText();
        this.LoadDamageText();
        this.LoadGoldText();
        this.LoadHeroSkillDescText();
        this.LoadSkillImage();
        this.LoadNameHeroText();

    }
    protected virtual void LoadHpText()
    {
        if (hpText != null) return;
        hpText = transform.Find("TextPanel/HpMpPanel/Hp_Text").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadNameHeroText()
    {
        if (nameHeroText != null) return;
        nameHeroText = transform.Find("TextPanel/NameCharacter").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadSkillImage()
    {
        if (skillImage != null) return;
        skillImage = transform.Find("TextPanel/SkillImage").GetComponent<Image>();
    }
    protected virtual void LoadHeroSkillDescText()
    {
        if (heroSkillDescText != null) return;
        heroSkillDescText = transform.Find("TextPanel/SkllDescription").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadMpText()
    {
        if (mpText != null) return;
        mpText = transform.Find("TextPanel/HpMpPanel/Mp_Text").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadDamageText()
    {
        if (damageText != null) return;
        damageText = transform.Find("TextPanel/DamageCoinPanel/Damge_Text").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadGoldText()
    {
        if (coinText != null) return;
        coinText = transform.Find("TextPanel/DamageCoinPanel/Gold_Text").GetComponent<TextMeshProUGUI>();
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
    public void Show()
    {
        gameObject.SetActive(true);

    }
    private void HandleHeroLevelUp(HeroSaveData heroSaveData)
    {
        if (this.heroHoverUI.HeroSaveData != heroSaveData) return;

        SetTextUpgrade();

    }
    protected virtual void SetTextUpgrade()
    {
        HeroSaveData saveData = heroHoverUI.HeroSaveData;
        hpText.text = "<color=yellow>Hp: </color><color=red>" + heroHoverUI.HeroSO.GetMaxHp(saveData.currentLevel + 1);
        mpText.text = "<color=yellow>Mp: </color><color=blue>" + heroHoverUI.HeroSO.GetMaxMp(saveData.currentLevel + 1) + "</color>";
        damageText.text = "<color=yellow>Damage: </color><color=orange>" + heroHoverUI.HeroSO.GetDame(saveData.currentLevel + 1) + "</color>";
        coinText.text = "<color=yellow>Coin: </color>" + heroHoverUI.HeroSO.GetPricent(saveData.currentLevel + 1);
      int dmg = heroHoverUI.HeroSO.GetDameSkill(saveData.currentLevel +1);
    int hpPercent = heroHoverUI.HeroSO.GetHpPercentHeal(saveData.currentLevel +1);   
    int freezeTime = heroHoverUI.HeroSO.GetFreezeTime(saveData.currentLevel +1); 
    
    var replacements = new Dictionary<string, string>
    {
        { "damage", $"<color=red>{dmg}</color>" },
        { "hpPercent", $"<color=green>{hpPercent}%</color>" },
        { "dongbang", $"<color=#00FFFF>{"đóng băng"}</color>" },
         { "daylui", $"<color=#8B4513>{"đẩy lùi"}</color>" },
           { "giay", $"<color=#FFFF00>{freezeTime}s</color>" },
    };

    string formattedDescription = SkillDescriptionFormatter.Format(heroHoverUI.HeroSO.skillDescription, replacements);
    heroSkillDescText.text = $"<color=yellow>Skill:</color> {formattedDescription}";
    }

    public void Hide()
    {

        gameObject.SetActive(false);
    }

    public void Setup(HeroHoverUI heroHoverUI)
    {
        this.heroHoverUI = heroHoverUI;
        SetTextUpgrade();
        this.SetSkillImage();
        this.SetNameHero();
    }

    public virtual void SetSkillImage()
    {
        skillImage.sprite = heroHoverUI.HeroSO.skillImage;
    }
      public virtual void SetNameHero()
    {
        nameHeroText.text = heroHoverUI.HeroSO.heroId;
    }
}
