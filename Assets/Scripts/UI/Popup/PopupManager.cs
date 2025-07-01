
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    private PopupMessageUI currentPopup;
    private string currentMessage;

    public void ShowPopup(string popupName, string message)
    {
        // Nếu đang hiển thị và trùng nội dung => bỏ qua
        if (message == currentMessage) return;
        if (currentPopup != null)
        {
            currentPopup.Despawn.DespawnObject();
        }
        // Spawn popup mới
        Transform popup = PopupSpawner.Instance.Spawn(popupName,Vector3.zero, Quaternion.identity);
        popup.localScale = new Vector3(1, 1, 1);
        currentPopup = popup.GetComponent<PopupMessageUI>();
        currentPopup.Show(message);
        currentMessage = message;
    }
    public virtual void OnPopupDespawned()
{
    currentPopup = null;
    currentMessage = null;
}

}
