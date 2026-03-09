using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public string uiID; // ID correspondant à celui envoyé par ScenePoint
    public GameObject uiRoot; // l'objet UI à activer (TitleScreen par exemple)

    void OnEnable()
    {
        EventManager.StartListening("ShowUI", OnShowUI);
    }

    void OnDisable()
    {
        EventManager.StopListening("ShowUI", OnShowUI);
    }

    void OnShowUI(EventParam param)
    {
        EventParamString stringParam = param as EventParamString;

        if (stringParam == null)
        {
            Debug.Log("[DEBUG][UI] ShowUI triggered without param");
            return;
        }

        Debug.Log($"[DEBUG][UI] Received ShowUI event : {stringParam.Value}");

        if (stringParam.Value == uiID)
        {
            ShowUI();
        }
    }

    void ShowUI()
    {
        if (uiRoot != null)
        {
            uiRoot.SetActive(true);
            Debug.Log($"[DEBUG][UI] UI '{uiID}' activated");
        }
        else
        {
            Debug.LogWarning("[DEBUG][UI] uiRoot reference missing");
        }
    }
}