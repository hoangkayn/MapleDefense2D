using UnityEngine;
using UnityEngine.Playables;

public class TimelinePauseHandler : BaseMonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] protected BtnBuyHero btnBuyHero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayableDirector();
        this.LoadBtnBuyHero();
    }
    protected virtual void LoadBtnBuyHero()
    {
        if (btnBuyHero != null) return;
        btnBuyHero = GameObject.Find("BtnSelect_Magician").GetComponent<BtnBuyHero>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        btnBuyHero.OnHeroBoughtFirstCutScene += ResumeTimeline;
        LevelByCoin.OnLevelUp += ResumeTimeline;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        btnBuyHero.OnHeroBoughtFirstCutScene -= ResumeTimeline;
         LevelByCoin.OnLevelUp -= ResumeTimeline;
    }
    protected virtual void LoadPlayableDirector()
    {
        if (director != null) return;
        director = transform.GetComponent<PlayableDirector>();
    }
    public void PauseTimeline()
    {
        director.Pause();
    }

    public void ResumeTimeline()
    {
        director.Resume(); // Unity 2022+
        // Hoặc: director.Play(); nếu dùng Unity 2021 hoặc cũ hơn
    }
}
