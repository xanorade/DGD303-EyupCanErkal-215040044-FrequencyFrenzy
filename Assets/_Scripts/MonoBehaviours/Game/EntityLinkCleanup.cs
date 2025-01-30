using Entitas.Unity;
using UnityEngine;

public class EntityLinkCleanup : MonoBehaviour
{
    public void RemoveAllEntityLinks()
    {
        // Sahnedeki tüm EntityLink bileşenlerine sahip GameObject'leri bul
        EntityLink[] allLinks = FindObjectsOfType<EntityLink>();

        // Her bir EntityLink bileşenini unlink et
        foreach (var link in allLinks)
        {
            if (link != null)
            {
                link.Unlink();
            }
        }

        Debug.Log("Tüm EntityLink'ler kaldırıldı!");
    }
}