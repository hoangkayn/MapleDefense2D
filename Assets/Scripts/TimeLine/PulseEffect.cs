using System.Collections;
using UnityEngine;

public class PulseEffect : BaseMonoBehaviour
{
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float speed = 2f;

    private RectTransform rectTransform;
    private bool isPulsing;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRectTransform();
    }
    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = transform.GetComponent<RectTransform>();
    }

   protected override void OnEnable()
    {
        isPulsing = true;
        StartCoroutine(Pulse());
    }

  protected override void OnDisable()
    {
        isPulsing = false;
        StopAllCoroutines();
        rectTransform.localScale = Vector3.one;
    }

    private IEnumerator Pulse()
    {
        while (isPulsing)
        {
            yield return ScaleTo(maxScale);
            yield return ScaleTo(minScale);
        }
    }

    private IEnumerator ScaleTo(float target)
    {
        Vector3 start = rectTransform.localScale;
        Vector3 end = Vector3.one * target;
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            rectTransform.localScale = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
}
