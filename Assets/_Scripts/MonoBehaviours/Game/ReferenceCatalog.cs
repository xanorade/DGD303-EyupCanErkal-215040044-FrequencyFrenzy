using UnityEngine;
using UnityEngine.Serialization;

public class ReferenceCatalog : MonoBehaviour
{
    [FormerlySerializedAs("PlayerPrefab")] [Header("Prefabs")]
    public GameObject playerPrefab;

    [Header("Enemy Prefab")]
    public GameObject enemyPrefab;

    [Header("Scene Objects")]
    public GameObject[] towerReferences;
    
    [Header("Projectiles")]
    public GameObject projectilePrefab;

    [Header("UI Elements")]
    public GameObject winScreen;

    public static ReferenceCatalog Instance;

    private void Awake()
    {
        Instance = this;
    }
}