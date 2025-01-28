using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceCatalog : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject PlayerPrefab;
    
    [Header("Scene Objects")]
    public GameObject[] towerReferences;
    
    public static ReferenceCatalog Instance;
    private void Awake()
    {
        Instance = this;
    }
}
