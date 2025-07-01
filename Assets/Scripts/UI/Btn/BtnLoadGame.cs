using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLoadGame : BaseButton
{
    protected override void OnClick()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }
}
