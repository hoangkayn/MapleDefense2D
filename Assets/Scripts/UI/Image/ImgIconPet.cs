using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgIconPet : BaseImg
{
    protected override void Start()
    {
        base.Start();
        PetSO petSO = PetDatabase.Instance.GetPetSO(GameDataManager.Instance.GetSelectedPetId());
        image.sprite = petSO.iconPet;
    }
}
