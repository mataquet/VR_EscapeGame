using UnityEngine;

public class Son_Fin : MonoBehaviour
{
    public AudioSource audioSource;

    bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !played )
        {
            Debug.Log("Fin !");
            audioSource.Play();
            played = true;
        }
    }
}
