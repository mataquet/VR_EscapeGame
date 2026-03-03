using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private int maxBounces = 5;
    [SerializeField] private LayerMask reflectionMask;
    [SerializeField] private LayerMask obstacleMask;

    [Header("Events")]
    public UnityEvent onTargetHit;
    public UnityEvent onTargetLost;

    private LineRenderer lineRenderer;
    private GameObject currentTarget;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        CastLaser();
    }

    void CastLaser()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        bool targetHitThisFrame = false;

        for (int i = 0; i < maxBounces; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance, reflectionMask | obstacleMask))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                if (((1 << hit.collider.gameObject.layer) & reflectionMask) != 0)
                {
                    Vector3 reflectionDir = Vector3.Reflect(ray.direction, hit.normal);
                    ray = new Ray(hit.point, reflectionDir);
                }
                else
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Target"))
                    {
                        targetHitThisFrame = true;
                        if (currentTarget != hit.collider.gameObject)
                        {
                            currentTarget = hit.collider.gameObject;
                            onTargetHit.Invoke();
                        }
                    }

                    break;
                }
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * maxDistance);
                break;
            }
        }

        if (!targetHitThisFrame && currentTarget != null)
        {
            currentTarget = null;
            onTargetLost.Invoke();
        }
    }
}
