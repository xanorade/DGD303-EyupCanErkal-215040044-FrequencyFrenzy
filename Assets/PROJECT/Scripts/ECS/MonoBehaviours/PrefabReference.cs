using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabReference : MonoBehaviour
{
    public GameObject PlayerPrefab;
    
    public static PrefabReference Instance;
    private void Awake()
    {
        Instance = this;
    }
}
