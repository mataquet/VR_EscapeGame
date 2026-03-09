using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ScenePoint : MonoBehaviour
{
    public string pointName;
    public bool triggerOnce = true;

    public bool triggered = false;

    [Serializable]
    public class ScenePointAction
    {
        public float delay;

        public ActionType actionType;

        public string dialogueID;

        public string uiID;

        public string interactableID;

        public string bgmID; // nouvel ID pour la musique de fond
    }

    public enum ActionType
    {
        StartDialogue,
        ShowUI,
        FreezePlayer,
        UnfreezePlayer,
        TriggerInteractable,
        PlayBGM // nouvel ActionType pour la musique
    }

    public List<ScenePointAction> actions = new List<ScenePointAction>();

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && triggered)
            return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            EventParamScenePoint param = new EventParamScenePoint
            {
                PointName = pointName,
                Position = transform.position
            };

            EventManager.TriggerEvent("ScenePointEntered", param);

            StartCoroutine(ExecuteActions());
        }
    }

    IEnumerator ExecuteActions()
    {
        foreach (var action in actions)
        {
            yield return new WaitForSeconds(action.delay);

            switch (action.actionType)
            {
                case ActionType.StartDialogue:
                    EventManager.TriggerEvent("StartDialogue", new EventParamString(action.dialogueID));
                    break;

                case ActionType.ShowUI:
                    EventManager.TriggerEvent("ShowUI", new EventParamString(action.uiID));
                    break;

                case ActionType.FreezePlayer:
                    EventManager.TriggerEvent("FreezePlayerControls", null);
                    break;

                case ActionType.UnfreezePlayer:
                    EventManager.TriggerEvent("UnfreezePlayerControls", null);
                    break;

                case ActionType.TriggerInteractable:
                    EventManager.TriggerEvent("TriggerInteractable", new EventParamString(action.interactableID));
                    break;

                case ActionType.PlayBGM:
                    EventManager.TriggerEvent("PlayBGM", new EventParamString(action.bgmID));
                    Debug.Log($"[DEBUG][ScenePoint] Triggered BGM: {action.bgmID}");
                    break;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}