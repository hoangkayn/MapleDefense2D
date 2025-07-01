using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRegister : BaseButton
{
    [SerializeField] protected PlayerNameInput playerNameInput;
    [SerializeField] protected SelectPetUI selectPetUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerNameInput();
        this.LoadSelectPetUI();
    }
    protected virtual void LoadPlayerNameInput()
    {
        if (playerNameInput != null) return;
        playerNameInput = transform.parent.GetComponentInChildren<PlayerNameInput>();
    }
      protected virtual void LoadSelectPetUI()
    {
        if (selectPetUI != null) return;
        selectPetUI = transform.parent.parent.GetComponentInChildren<SelectPetUI>();
    }
    protected override void OnClick()
    {
        string playerName = playerNameInput.InputField.text;

        if (!NameValidator.IsValid(playerName, out string error))
        {
             PopupManager.Instance.ShowPopup(PopupSpawner.PopupError,error); // hiện popup lỗi
            return;
        }
        GameDataManager.Instance.CreateNewGameDefault();
        GameDataManager.Instance.AddPetFirst(selectPetUI.GetCurrentPetSO().idName);
        PlayerSaveData playerSaveData = new PlayerSaveData(playerName, 1, 0);
        GameDataManager.Instance.SetPlayer(playerSaveData);
        GameDataManager.Instance.ApplyRuntimeSystems();
        SceneLoader.Instance.LoadScene("CutScene Instructor");
    }
}
