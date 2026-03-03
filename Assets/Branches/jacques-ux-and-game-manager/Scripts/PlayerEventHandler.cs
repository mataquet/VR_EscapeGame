using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerEventHandler : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider moveProvider;
    public ActionBasedContinuousTurnProvider turnProvider;
    public EyeBlinkEffect eyeBlink;

    void OnEnable()
    {
        GameEvents.OnLockPlayer += LockPlayer;
        GameEvents.OnUnlockPlayer += UnlockPlayer;
        GameEvents.OnBlinkOnce += Blink;
    }

    void OnDisable()
    {
        GameEvents.OnLockPlayer -= LockPlayer;
        GameEvents.OnUnlockPlayer -= UnlockPlayer;
        GameEvents.OnBlinkOnce -= Blink;
    }

    void LockPlayer()
    {
        moveProvider.enabled = false;
        turnProvider.enabled = false;
    }

    void UnlockPlayer()
    {
        moveProvider.enabled = true;
        turnProvider.enabled = true;
    }

    void Blink()
    {
        eyeBlink.BlinkOnce();
    }
}
