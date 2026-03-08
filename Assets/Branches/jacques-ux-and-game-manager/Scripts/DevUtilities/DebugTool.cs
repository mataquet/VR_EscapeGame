using UnityEngine;

public class DebugTool : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("ScenePointEntered", OnScenePointEntered);
        EventManager.StartListening("StartDialogue", OnStartDialogue);
        EventManager.StartListening("ShowUI", OnShowUI);
        EventManager.StartListening("FreezePlayerControls", OnFreezePlayer);
        EventManager.StartListening("UnfreezePlayerControls", OnUnfreezePlayer);
        EventManager.StartListening("TriggerInteractable", OnTriggerInteractable);
    }

    void OnDisable()
    {
        EventManager.StopListening("ScenePointEntered", OnScenePointEntered);
        EventManager.StopListening("StartDialogue", OnStartDialogue);
        EventManager.StopListening("ShowUI", OnShowUI);
        EventManager.StopListening("FreezePlayerControls", OnFreezePlayer);
        EventManager.StopListening("UnfreezePlayerControls", OnUnfreezePlayer);
        EventManager.StopListening("TriggerInteractable", OnTriggerInteractable);
    }

    void OnScenePointEntered(EventParam param)
    {
        EventParamScenePoint sceneParam = param as EventParamScenePoint;

        if (sceneParam != null)
        {
            Debug.Log(
                $"[DEBUG][ScenePoint] Player entered : {sceneParam.PointName} at {sceneParam.Position}"
            );
        }
        else
        {
            Debug.Log("[DEBUG][ScenePoint] Triggered without param");
        }
    }

    void OnStartDialogue(EventParam param)
    {
        EventParamString p = param as EventParamString;

        if (p != null)
            Debug.Log($"[DEBUG][Dialogue] Start dialogue : {p.Value}");
        else
            Debug.Log("[DEBUG][Dialogue] StartDialogue triggered without ID");
    }

    void OnShowUI(EventParam param)
    {
        EventParamString p = param as EventParamString;

        if (p != null)
            Debug.Log($"[DEBUG][UI] Show UI : {p.Value}");
        else
            Debug.Log("[DEBUG][UI] ShowUI triggered without ID");
    }

    void OnFreezePlayer(EventParam param)
    {
        Debug.Log("[DEBUG][Player] Controls FROZEN");
    }

    void OnUnfreezePlayer(EventParam param)
    {
        Debug.Log("[DEBUG][Player] Controls UNFROZEN");
    }

    void OnTriggerInteractable(EventParam param)
    {
        EventParamString p = param as EventParamString;

        if (p != null)
            Debug.Log($"[DEBUG][Interactable] Trigger interactable : {p.Value}");
        else
            Debug.Log("[DEBUG][Interactable] TriggerInteractable without ID");
    }
}