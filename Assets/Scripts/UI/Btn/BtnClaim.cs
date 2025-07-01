using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClaim : BaseButton
{
    protected override void OnClick()
    {
        this.LoadSceneMainMenu();
    }
    protected virtual void LoadSceneMainMenu()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.LoadScene("MainMenu");
    }

}
