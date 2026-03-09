using UnityEngine;

public class ChariotAudio : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartSound()
    {
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}