using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public ScenePoint[] scenePoints;
    public Transform player;
    public float triggerDistance = 2f;

    void Update()
    {
        foreach (var point in scenePoints)
        {
            if (Vector3.Distance(player.position, point.transform.position) <= triggerDistance)
            {
                point.Activate();
            }
        }
    }
}
