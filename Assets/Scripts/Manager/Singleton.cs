using UnityEngine;
public abstract class Singleton<T> : BaseMonoBehaviour where T : BaseMonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null) Debug.LogError($"{typeof(T)} not found in scene!");
            }
            return _instance;
        }
    }

    protected override void Awake()
    {
        if (_instance == null) _instance = this as T;
        else if (_instance != this) Destroy(gameObject); 
    }
}
