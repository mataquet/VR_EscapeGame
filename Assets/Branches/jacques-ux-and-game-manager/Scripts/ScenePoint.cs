using UnityEngine;
using System;

public class ScenePoint : MonoBehaviour
{
    public string pointName;
    public bool triggerOnce = true;

    public Action onEnter;
    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && triggered)
            return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            onEnter?.Invoke();

            EventParamScenePoint param = new EventParamScenePoint
            {
                PointName = pointName,
                Position = transform.position
            };

            EventManager.TriggerEvent("ScenePointEntered", param);

            Debug.Log($"ScenePoint {pointName} triggered!");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}