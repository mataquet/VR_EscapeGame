using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class GameEvents
{
    public static Action OnLockPlayer;
    public static Action OnUnlockPlayer;
    public static Action OnBlinkOnce;
}
