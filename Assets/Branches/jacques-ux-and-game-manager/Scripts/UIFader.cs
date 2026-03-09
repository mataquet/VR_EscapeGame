using System.Collections;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    [Header("Fade Settings")]
    public float fadeInDuration = 2f;
    public float fadeOutDuration = 2f;
    public float stayDuration = 3f;

    void Start()
    {
        canvasGroup.alpha = 0f;
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        yield return StartCoroutine(Fade(0f, 1f, fadeInDuration));
        yield return new WaitForSeconds(stayDuration);
        yield return StartCoroutine(Fade(1f, 0f, fadeOutDuration));
    }

    IEnumerator Fade(float start, float end, float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, time / duration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}