using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        //Debug.Log("GM: Start");

        //if (UIEventManager.Instance != null)
        //    UIEventManager.Instance.StartEyeFatigue();
        //else
        //    Debug.LogWarning("UIEventManager not ready");

    }

}
