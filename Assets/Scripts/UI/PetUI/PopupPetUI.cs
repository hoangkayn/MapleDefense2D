using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupPetUI : BaseMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textNamePet;
    [SerializeField] protected TextMeshProUGUI textDescription;
    [SerializeField] protected TextMeshProUGUI textEffect;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextNamePet();
        this.LoadTextDescription();
        this.LoadTextEffect();
    }
    protected virtual void LoadTextNamePet()
    {
        if (textNamePet != null) return;
        textNamePet = transform.Find("TopFrame").GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void LoadTextDescription()
    {
        if (textDescription != null) return;
        textDescription = transform.Find("TxtDescription").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadTextEffect()
    {
        if (textEffect != null) return;
        textEffect = transform.Find("TxtEffect").GetComponent<TextMeshProUGUI>();
    }
    public virtual void SetText(PetSO petSO)
    {
        textNamePet.text = petSO.idName;
        textDescription.text = petSO.description;
        textEffect.text = "<color=yellow>Effect: </color>" + petSO.description;
        SetEffectText(petSO);
    }
    protected virtual void SetEffectText(PetSO petSO)
    {
        string effectText = "";
        foreach (ItemBonus bonus in petSO.itemBonus)
        {
            effectText += $"x{bonus.bonusMultiplier} {bonus.rewardSO.rewardType}\n";
        }

        foreach (SpecialBonus bonus in petSO.specialBonus)
        {
            effectText += $"x{bonus.bonusMultiplier} {bonus.specialReward}\n";
        }

        textEffect.text = effectText.TrimEnd();
    }
}
