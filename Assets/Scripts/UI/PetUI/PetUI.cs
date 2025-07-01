using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetUI : BaseMonoBehaviour
{
    [SerializeField] protected PetSO petSO;
    public PetSO PetSO => petSO;
    public PetSaveData petSaveData;
    [SerializeField] protected TextMeshProUGUI nameText;
    [SerializeField] protected TextMeshProUGUI typeText;
    [SerializeField] protected ImgSelectedPet imgSelectedPet;
    [SerializeField] protected PopupPetUI popupPetUI;
    public PopupPetUI PopupPetUI => popupPetUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPetSO();
        this.LoadNameText();
        this.LoadTypeText();
        this.LoadImgSelectedPet();
        this.LoadPopUpPetUI();
    }
    protected virtual void LoadPopUpPetUI()
    {
          if (popupPetUI != null) return;
        popupPetUI = transform.GetComponentInChildren<PopupPetUI>(true);
    }
    protected virtual void LoadImgSelectedPet()
    {
        if (imgSelectedPet != null) return;
        imgSelectedPet = transform.GetComponentInChildren<ImgSelectedPet>();
    }
    protected override void Start()
    {
        base.Start();
        imgSelectedPet.Show(petSO);
         popupPetUI.SetText(petSO);
    }
    protected virtual void LoadNameText()
    {
        if (nameText != null) return;
        nameText = transform.Find("TxtName").GetComponent<TextMeshProUGUI>();
        nameText.text = petSO.idName;
    }
    protected virtual void LoadTypeText()
    {
        if (typeText != null) return;
        typeText = transform.Find("TextType").GetComponent<TextMeshProUGUI>();
        typeText.text = petSO.petRank.ToString();
    }
    protected virtual void LoadPetSO()
    {
        if (petSO != null) return;
        string id = transform.name.Replace("Slot_", "");
        petSO = PetDatabase.Instance.GetPetSO(id);
    }
}
