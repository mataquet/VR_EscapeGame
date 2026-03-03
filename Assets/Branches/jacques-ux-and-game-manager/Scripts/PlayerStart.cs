using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject introUI; // UI à afficher au début

    void Start()
    {
        // Bloquer le joueur au démarrage
        introUI.SetActive(true);
    }

    public void BeginIntro()
    {
        // Appelé par GameManager ou bouton "Start"
        introUI.SetActive(false);
    }
}
