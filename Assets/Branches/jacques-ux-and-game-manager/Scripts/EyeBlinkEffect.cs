using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EyeBlinkEffect : MonoBehaviour
{
    public Image blinkImage;
    public float blinkDuration = 0.15f;
    public float fatigueInterval = 4f;

    Coroutine routine;

    void Awake()
    {
        blinkImage.color = new Color(0, 0, 0, 0);
        blinkImage.gameObject.SetActive(false);
    }

    // ===== API =====

    public void StartFatigue()
    {
        if (routine == null)
            routine = StartCoroutine(FatigueLoop());
    }

    public void StopFatigue()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }

        blinkImage.gameObject.SetActive(false);
    }

    public void BlinkOnce()
    {
        StartCoroutine(Blink());
    }

    // ===== CORE =====

    IEnumerator FatigueLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(fatigueInterval);
            yield return Blink();
        }
    }

    IEnumerator Blink()
    {
        blinkImage.gameObject.SetActive(true);

        yield return Fade(0f, 1f);
        yield return new WaitForSeconds(0.05f);
        yield return Fade(1f, 0f);

        blinkImage.gameObject.SetActive(false);
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        while (t < blinkDuration)
        {
            t += Time.deltaTime;
            blinkImage.color = new Color(0, 0, 0, Mathf.Lerp(from, to, t / blinkDuration));
            yield return null;
        }
    }
}
