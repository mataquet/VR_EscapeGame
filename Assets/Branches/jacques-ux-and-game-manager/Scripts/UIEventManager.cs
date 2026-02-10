using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager Instance { get; private set; }

    [Header("Camera Effects")]
    public EyeBlinkEffect eyeBlinkEffect;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // API UI

    public void StartEyeFatigue()
    {
        eyeBlinkEffect.StartFatigue();
    }

    public void StopEyeFatigue()
    {
        eyeBlinkEffect.StopFatigue();
    }

    public void BlinkOnce()
    {
        eyeBlinkEffect.BlinkOnce();
    }
}
