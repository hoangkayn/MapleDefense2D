
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum PetButtonState
{
    Buy,
    Selectable,
    Selected
}
public class BtnPricePet : BaseButton
{
    [SerializeField] protected PetUI petUI;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected PetButtonState currentState;
    [SerializeField] protected Image image;
    [SerializeField] protected Image icon;
    protected Sprite buySprite;
    protected Sprite selectableSprite;
    protected Sprite selectedSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetUI();
        this.LoadPriceText();
        this.LoadSprites();
        this.LoadImage();
        this.LoadPriceText();
        this.LoadIcon();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.GetComponent<Image>();
    }
     protected virtual void LoadIcon()
    {
        if (icon != null) return;
        icon = transform.Find("Image").GetComponent<Image>();
    }
    protected virtual void LoadSprites()
    {
        if (buySprite == null)
            buySprite = Resources.Load<Sprite>("UI/PetButton/img_buy");
        if (selectableSprite == null)
            selectableSprite = Resources.Load<Sprite>("UI/PetButton/img_select");
        if (selectedSprite == null)
            selectedSprite = Resources.Load<Sprite>("UI/PetButton/img_selected");
    }
    protected override void Start()
    {
        base.Start();
        SetStateBtn(petUI.PetSO.idName);
    }
    protected virtual void SetStateBtn(string id)
    {
        bool isSelected = GameDataManager.Instance.IsSelected(id);
        bool isPurchased = GameDataManager.Instance.IsPetPurchased(id);
        if (isSelected)
        {
            currentState = PetButtonState.Selected;
        }
        else if (isPurchased)
        {
            currentState = PetButtonState.Selectable;
        }
        else
        {
            currentState = PetButtonState.Buy;
        }
        UpdateUI();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        GameDataManager.BtnSelectPet += HandleSelectPet;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
         GameDataManager.BtnSelectPet -= HandleSelectPet;
    }
    protected virtual void HandleSelectPet()
    {
        if (currentState == PetButtonState.Selected)
        {
            currentState = PetButtonState.Selectable;
        }
        UpdateUI();
}
    
    protected virtual void LoadPriceText()
    {
        if (priceText != null) return;
        priceText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void LoadPetUI()
    {
        if (petUI != null) return;
        petUI = transform.parent.GetComponent<PetUI>();
    }
    protected override void OnClick()
    {
     
    if (currentState == PetButtonState.Selected) return;

    switch (currentState)
    {
        case PetButtonState.Buy:
                if (!CurrencyManager.Instance.SpendGem(petUI.PetSO.price))
                {
                     PopupManager.Instance.ShowPopup(PopupSpawner.PopupError,"Không Đủ Gem!");
                    return;
            }
            GameDataManager.Instance.BuyPet(petUI.PetSO.idName);
            currentState = PetButtonState.Selectable;
                PopupManager.Instance.ShowPopup(PopupSpawner.PopupSuccess,"Mua Thành Công");
            break;

        case PetButtonState.Selectable:
            GameDataManager.Instance.SelectPet(petUI.PetSO.idName);
            currentState = PetButtonState.Selected;
             PopupManager.Instance.ShowPopup(PopupSpawner.PopupSelected,"Đã chọn");
            break;
    }

    UpdateUI();
}

    
    protected virtual void UpdateUI()
    {
        switch (currentState)
        {
       case PetButtonState.Buy:
                image.sprite = buySprite;
                priceText.text = petUI.PetSO.price.ToString();
                icon.gameObject.SetActive(true);
                break;
            case PetButtonState.Selectable:
                image.sprite = selectableSprite;
                priceText.text = "Chọn";
                  icon.gameObject.SetActive(false);
                break;
            case PetButtonState.Selected:
                image.sprite = selectedSprite;
                icon.gameObject.SetActive(false);
                priceText.text = "Đã chọn";
                break;
       }
    }
}
