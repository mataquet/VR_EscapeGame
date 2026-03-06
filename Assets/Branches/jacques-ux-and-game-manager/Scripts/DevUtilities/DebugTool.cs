using UnityEngine;

public class DebugTool : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("ScenePointEntered", OnScenePointEntered);
    }

    void OnDisable()
    {
        EventManager.StopListening("ScenePointEntered", OnScenePointEntered);
    }

    void Update()
    {
    }

    void OnScenePointEntered(EventParam param)
    {
        EventParamScenePoint sceneParam = param as EventParamScenePoint;

        if (sceneParam != null)
        {
            Debug.Log(
                $"[DEBUG] Player entered ScenePoint : {sceneParam.PointName} at {sceneParam.Position}"
            );
        }
        else
        {
            Debug.Log("[DEBUG] ScenePointEntered triggered without param");
        }
    }
}