using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> starList;
    public List<Transform> StarList => starList;
    [SerializeField] protected float timerDelay = 0.2f;
    [SerializeField] protected StarSO starSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStars();
        this.LoadStarSO();
       
    }
    protected virtual void LoadStarSO()
    {
        if (starSO != null) return;
        string resPath = "SO/Star/Star";
        this.starSO = Resources.Load<StarSO>(resPath);
    }
    protected virtual void LoadStars()
    {
        if (starList.Count > 0) return;
        foreach (Transform star in transform)
        {
            starList.Add(star);
            foreach (Transform child in star)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    
    protected virtual IEnumerator ActivateStarsWithDelay (int totalStars)
    {
        for (int i = 0; i < totalStars; i++)
        {
            this.ActiveStar(StarList[i]);
            yield return new WaitForSecondsRealtime(timerDelay);
        }
    }
    public virtual void DisplayStars(int startCount)
    {
        StartCoroutine(ActivateStarsWithDelay(startCount));
    }
    protected virtual void ActiveStar(Transform obj)
    {
        foreach (Transform child in obj)
        {
            child.gameObject.SetActive(true);
        }
    }
}
