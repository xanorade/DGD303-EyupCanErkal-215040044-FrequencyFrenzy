using UnityEngine;
using UnityEngine.Serialization;

public class ReferenceCatalog : MonoBehaviour
{
    [FormerlySerializedAs("PlayerPrefab")] [Header("Prefabs")]
    public GameObject playerPrefab;
    
    [Header("Scene Objects")]
    public GameObject[] towerReferences;
    
    public static ReferenceCatalog Instance;
    private void Awake()
    {
        Instance = this;
    }
}