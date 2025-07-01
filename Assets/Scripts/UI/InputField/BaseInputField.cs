using UnityEngine;
using TMPro;

public abstract class BaseTMPInputField : BaseMonoBehaviour
{
    [Header("Base TMP Input Field")]
    [SerializeField] protected TMP_InputField inputField;
    public TMP_InputField InputField => inputField;

    protected override void Start()
    {
        base.Start();
        AddOnValueChangedEvent();
        AddOnEndEditEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInputField();
    }

    protected virtual void LoadInputField()
    {
        if (inputField != null) return;
        inputField = GetComponent<TMP_InputField>();
    }

    protected virtual void AddOnValueChangedEvent()
    {
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    protected virtual void AddOnEndEditEvent()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    protected abstract void OnValueChanged(string value);
    protected virtual void OnEndEdit(string value) { }
}
