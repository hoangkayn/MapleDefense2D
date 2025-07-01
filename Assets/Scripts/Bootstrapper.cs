using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PerformBootstrap
{
    const string SceneName = "BootstrapScene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        // traverse the currently loaded scenes
        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            // early out if already loaded
            if (candidate.name == SceneName)
                return;
        }

        Debug.Log("Loading bootstrap scene: " + SceneName);

        // additively load the bootstrap scene
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }
}

public class Bootstrapper : MonoBehaviour
{
    public static Bootstrapper Instance { get; private set; } = null;

    void Awake()
    {
        // check if an instance already exists
        if (Instance != null)
        {
            Debug.LogError("Tìm thấy một BootstrappedData khác trên " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Debug.Log("Bootstrap đã được khởi tạo!");
        Instance = this;

        // prevent the data from being unloaded
        DontDestroyOnLoad(gameObject);
    }

    public void Test()
    {
        Debug.Log("Bootstrap đang hoạt động!");
    }
}