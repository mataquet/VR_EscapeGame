using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{
    [Header("Intensity")]
    public float minIntensity = 0f;
    public float maxIntensity = 5f;

    [Header("Flicker")]
    public float minFlickerSpeed = 0.05f;
    public float maxFlickerSpeed = 0.2f;

    [Header("Blink")]
    [Tooltip("Chance de blink (0 = jamais, 1 = tout le temps)")]
    [Range(0f, 1f)] public float blinkChance = 0.15f;
    public float minBlinkDuration = 0.05f;
    public float maxBlinkDuration = 0.2f;

    private Light _light;
    private float targetIntensity;
    private float timer;
    private bool isBlinking;

    void Awake()
    {
        _light = GetComponent<Light>();
        targetIntensity = maxIntensity;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (!isBlinking)
        {
            _light.intensity = Mathf.Lerp(
                _light.intensity,
                targetIntensity,
                Time.deltaTime * 12f
            );
        }

        if (timer <= 0f)
        {
            PickNewState();
        }
    }

    void PickNewState()
    {
        // Décide si on blink
        if (Random.value < blinkChance)
        {
            StartCoroutine(Blink());
        }
        else
        {
            isBlinking = false;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            timer = Random.Range(minFlickerSpeed, maxFlickerSpeed);
        }
    }

    System.Collections.IEnumerator Blink()
    {
        isBlinking = true;

        float previousIntensity = _light.intensity;
        _light.intensity = 0f;

        float blinkTime = Random.Range(minBlinkDuration, maxBlinkDuration);
        yield return new WaitForSeconds(blinkTime);

        _light.intensity = previousIntensity;
        isBlinking = false;

        timer = Random.Range(minFlickerSpeed, maxFlickerSpeed);
    }
}
