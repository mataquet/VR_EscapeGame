using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class ScenePoint : MonoBehaviour
{
    public string pointName;
    public bool triggerOnce = true;

    public Action onEnter; // actions à exécuter

    private bool triggered = false;

    public void Activate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        onEnter?.Invoke();
        Debug.Log($"ScenePoint {pointName} triggered!");
    }


    // Optionnel : pour visualiser le point dans la scène
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
        UnityEditor.Handles.Label(transform.position + Vector3.up * 0.5f, pointName);
    }
}
