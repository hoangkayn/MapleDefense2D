using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBackStartGame : BaseButton
{
    protected override void OnClick()
    {
        SceneLoader.Instance.LoadScene("StartGame");
    }
}
