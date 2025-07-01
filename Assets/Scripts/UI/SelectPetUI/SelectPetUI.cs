using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectPetUI : BaseMonoBehaviour
{
    [SerializeField] protected ImgSelectedPet imgSelectedPet;
    [SerializeField] protected TextMeshProUGUI txtNamePet;
    [SerializeField] protected List<PetSO> availablePets;
    protected int currentIndex;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImgSelectedPet();
        this.LoadTxtNamePet();
        this.LoadPetSOs();
    }
    public virtual PetSO GetCurrentPetSO()
    {
        return availablePets[currentIndex];
    }
    protected virtual void LoadPetSOs()
    {
        if (availablePets.Count > 0) return;
        foreach (PetSO petSO in PetDatabase.Instance.pets)
        {
            if (petSO.petRank != PetRank.Normal) continue;
            availablePets.Add(petSO);
        }
    }
    protected override void Start()
    {
        base.Start();
        UpdatePetDisplay();
    }
    protected virtual void LoadImgSelectedPet()
    {
        if (imgSelectedPet != null) return;

        imgSelectedPet = transform.Find("PetDisplay/ImgPet").GetComponent<ImgSelectedPet>();
    }
    protected virtual void LoadTxtNamePet()
    {
        if (txtNamePet != null) return;
        txtNamePet = transform.Find("PetDisplay/FrameTxt/TxtNamePet").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void UpdatePetDisplay()
    {
        PetSO pet = availablePets[currentIndex];
        txtNamePet.text = pet.idName;
        imgSelectedPet.Show(pet);
    }
    public void SelectNextPet()
    {
        currentIndex = (currentIndex + 1) % availablePets.Count;
        UpdatePetDisplay();
    }
     public void SelectPreviousPet()
    {
        currentIndex = (currentIndex - 1 + availablePets.Count) % availablePets.Count;
        UpdatePetDisplay();
    }
}
