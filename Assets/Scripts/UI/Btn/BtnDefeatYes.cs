using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnDefeatYes : BaseButton
{
    protected override void OnClick()
    {
         Time.timeScale = 1;
        SceneLoader.Instance.LoadScene("MainGame");
    
    }
}
