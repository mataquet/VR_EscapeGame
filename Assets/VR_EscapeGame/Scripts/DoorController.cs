using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private Vector3 moveOffset = new Vector3(0, 2.5f, 0);
    [SerializeField] private float duration = 2.0f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip moveSound;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private Coroutine currentCoroutine;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + moveOffset;
    }

    public void Open()
    {
        if (isOpen) return;

        PlaySound();
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveToTarget(openPosition));
        isOpen = true;
    }

    public void Close()
    {
        if (!isOpen) return;

        PlaySound();
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveToTarget(closedPosition));
        isOpen = false;
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    private void PlaySound()
    {
        if (audioSource != null && moveSound != null)
        {
            audioSource.PlayOneShot(moveSound);
        }
    }
}
