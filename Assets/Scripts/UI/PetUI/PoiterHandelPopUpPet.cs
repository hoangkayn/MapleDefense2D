using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoiterHandelPopUpPet : BaseMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected PetUI petUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetUI();
    }
    protected virtual void LoadPetUI()
    {
        if (petUI != null) return;
        petUI = transform.parent.GetComponent<PetUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
         petUI.PopupPetUI.gameObject.SetActive(true);
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        petUI.PopupPetUI.gameObject.SetActive(false);
    }
}
