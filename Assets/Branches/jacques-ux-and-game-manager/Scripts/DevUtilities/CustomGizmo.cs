using UnityEditor;
using UnityEngine;

public class CustomGizmo : MonoBehaviour
{
    [Tooltip("Icône à afficher dans la scène")]
    public Texture2D icon;

    [Tooltip("Taille de l'icône (optionnel, pour ajuster)")]
    public float iconSize = 1f;

    void OnDrawGizmos()
    {
        if (icon != null)
        {
            // 'true' = icon est visible même quand l'objet n'est pas sélectionné
            //Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(icon), true);
        }
        else
        {
            // fallback : une sphère si pas d'icône assignée
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
        }
    }
}