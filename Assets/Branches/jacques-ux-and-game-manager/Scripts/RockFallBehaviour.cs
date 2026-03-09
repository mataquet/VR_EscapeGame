using UnityEngine;

public class RockFallBehaviour : MonoBehaviour
{
    public GameObject StaticRocks;
    public GameObject DynamicRocks;

    [SerializeField] private bool rockFall;

    public string interactableID; // ID qui déclenche l'éboulement

    void OnEnable()
    {
        EventManager.StartListening("TriggerInteractable", OnTriggerInteractable);
    }

    void OnDisable()
    {
        EventManager.StopListening("TriggerInteractable", OnTriggerInteractable);
    }

    void OnTriggerInteractable(EventParam param)
    {
        EventParamString stringParam = param as EventParamString;

        if (stringParam == null)
        {
            Debug.Log("[DEBUG][RockFall] TriggerInteractable without param");
            return;
        }

        Debug.Log($"[DEBUG][RockFall] Received interactable trigger : {stringParam.Value}");

        if (stringParam.Value == interactableID)
        {
            Debug.Log($"[DEBUG][RockFall] Matching interactableID '{interactableID}'");

            TriggerRockFall();
        }
    }

    public void TriggerRockFall()
    {
        if (rockFall)
        {
            Debug.Log("[DEBUG][RockFall] Rock fall already triggered");
            return;
        }

        rockFall = true;

        if (StaticRocks != null)
            StaticRocks.SetActive(false);

        if (DynamicRocks != null)
            DynamicRocks.SetActive(true);

        Debug.Log("[DEBUG][RockFall] Rock fall triggered!");
    }
}