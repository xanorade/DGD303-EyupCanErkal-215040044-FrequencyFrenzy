using System;
using UnityEngine;

public class GameCreator : MonoBehaviour
{
    private Contexts _contexts;
    
    private PlayerMovementFeature _playerMovementFeature;
    private PlayerFeature _playerFeature;
    private PowerUpFeature _powerUpFeature;

    private void Awake()
    {
        _playerFeature = new PlayerFeature(Contexts.sharedInstance);
        _playerFeature.Initialize();
    }

    private void Start()
    {
        _playerMovementFeature = new PlayerMovementFeature(Contexts.sharedInstance);
        _powerUpFeature = new PowerUpFeature(Contexts.sharedInstance);
    }

    private void Update()
    {
        _playerMovementFeature.Execute();
        _powerUpFeature.Execute();
    }
}
