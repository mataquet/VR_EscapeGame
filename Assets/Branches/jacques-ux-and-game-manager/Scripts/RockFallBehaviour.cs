using UnityEngine;

public class RockFallBehaviour : MonoBehaviour
{
    public GameObject StaticRocks;
    public GameObject DynamicRocks;

    [SerializeField] private bool rockFall;

    public string triggerPointName; // nom du ScenePoint qui déclenche l'éboulement

    void OnEnable()
    {
        EventManager.StartListening("ScenePointEntered", OnScenePointEntered);
    }

    void OnDisable()
    {
        EventManager.StopListening("ScenePointEntered", OnScenePointEntered);
    }

    void OnScenePointEntered(EventParam param)
    {
        EventParamScenePoint sceneParam = param as EventParamScenePoint;

        if (sceneParam == null)
            return;

        if (sceneParam.PointName == triggerPointName)
        {
            TriggerRockFall();
        }
    }

    public void TriggerRockFall()
    {
        rockFall = true;

        StaticRocks.SetActive(false);
        DynamicRocks.SetActive(true);

        Debug.Log("Rock fall triggered!");
    }
}