using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    [Header("UI References")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Slider slider;
    [SerializeField] private float fadeDuration = 0.5f;
     private Dictionary<string, string> sceneToBgmMap = new()
    {
        { "MainMenu", "BGM_MainMenu" },
        { "MainGame", "BGM_MainGame" },
        { "SelectPet", "BGM_PetSelect" },
          { "CutScene Instructor", "BGM_CutScene" },
           { "StartGame", "BGM_StartGame" },
    };

    protected override void Awake()
    {

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCanvasGroup();
        this.LoadSlider();
    }
    protected virtual void LoadCanvasGroup()
    {
        if (canvasGroup != null) return;
        canvasGroup = transform.GetComponent<CanvasGroup>();
    }
     protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponentInChildren<Slider>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

   private IEnumerator LoadSceneRoutine(string sceneName)
{
    slider.value = 0f;
    yield return StartCoroutine(FadeIn());

    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    operation.allowSceneActivation = false;

    while (operation.progress < 0.9f)
    {
        slider.value = Mathf.Clamp01(operation.progress / 0.9f);
        yield return null;
    }
    slider.value = 1f;
   yield return new WaitForSeconds(1f);

    operation.allowSceneActivation = true;

    yield return null;
    yield return StartCoroutine(FadeOut());

    if (sceneToBgmMap.TryGetValue(sceneName, out string bgmId))
    {
        AudioManager.Instance.Play(bgmId);
    }
    else
    {
        Debug.LogWarning($"No BGM mapped for scene: {sceneName}");
    }
}


    private IEnumerator FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    private IEnumerator FadeOut()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
