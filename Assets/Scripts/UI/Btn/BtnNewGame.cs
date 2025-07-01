using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNewGame : BaseButton
{
    protected override void OnClick()
    {
        SceneLoader.Instance.LoadScene("SelectPet");
    }
}
