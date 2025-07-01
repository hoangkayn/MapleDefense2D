using UnityEngine;

public class PlayerNameInput : BaseTMPInputField
{
    protected override void OnValueChanged(string value)
    {
        Debug.Log("Đang nhập tên: " + value);
    }

    protected override void OnEndEdit(string value)
    {
        Debug.Log("Kết thúc nhập tên: " + value);
     //   GameDataManager.Instance.SetPlayer(new PlayerSaveData(value, 1, 0));
    }
}
