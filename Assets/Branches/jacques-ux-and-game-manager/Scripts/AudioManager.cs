using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioClip[] bgmClips;

    public AudioSource voiceAudioSource;
    public AudioClip[] voiceClips;

    void OnEnable()
    {
        EventManager.StartListening("PlayBGM", OnPlayBGM);
        EventManager.StartListening("StartDialogue", OnStartDialogue);
    }

    void OnDisable()
    {
        EventManager.StopListening("PlayBGM", OnPlayBGM);
        EventManager.StopListening("StartDialogue", OnStartDialogue);
    }

    void OnPlayBGM(EventParam param)
    {
        EventParamString p = param as EventParamString;
        if (p == null) return;

        AudioClip clip = Array.Find(bgmClips, c => c.name == p.Value);

        if (clip != null)
        {
            bgmAudioSource.clip = clip;

            if (clip.name == "Main_BGM")
                bgmAudioSource.time = 24f;

            bgmAudioSource.Play();
            Debug.Log($"[DEBUG][BGMusicManager] Playing BGM: {p.Value}");
        }
        else
        {
            Debug.LogWarning($"[DEBUG][BGMusicManager] BGM clip not found: {p.Value}");
        }
    }

    void OnStartDialogue(EventParam param)
    {
        EventParamString p = param as EventParamString;
        if (p == null) return;

        AudioClip clip = Array.Find(voiceClips, c => c.name == p.Value);

        if (clip != null)
        {
            voiceAudioSource.clip = clip;
            voiceAudioSource.Play();
            Debug.Log($"[DEBUG][BGMusicManager] Playing Voice Dialogue: {p.Value}");
        }
        else
        {
            Debug.LogWarning($"[DEBUG][BGMusicManager] Voice Dialogue clip not found: {p.Value}");
        }
    }
}