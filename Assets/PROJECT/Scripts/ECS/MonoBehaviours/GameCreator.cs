using System;
using UnityEngine;

public class GameCreator : MonoBehaviour
{
    private Contexts _contexts;
    
    private PlayerInputFeature _playerInputFeature;
    private PlayerMovementFeature _playerMovementFeature;
    private PlayerFeature _playerFeature;
    private PowerUpFeature _powerUpFeature;
    private EnemyFeature _enemyFeature;
    private ViewFeature _viewFeature;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _playerInputFeature = new PlayerInputFeature(Contexts.sharedInstance);
        _playerMovementFeature = new PlayerMovementFeature(Contexts.sharedInstance);
        _powerUpFeature = new PowerUpFeature(Contexts.sharedInstance);
        _playerFeature = new PlayerFeature(Contexts.sharedInstance);
        _enemyFeature = new EnemyFeature(Contexts.sharedInstance);
        _viewFeature = new ViewFeature(Contexts.sharedInstance);
        
        _playerInputFeature.Initialize();
        _playerMovementFeature.Initialize();
        _powerUpFeature.Initialize();
        _playerFeature.Initialize();
        _enemyFeature.Initialize();
        _viewFeature.Initialize();
    }

    private void Update()
    {
        _playerInputFeature.Execute();
        _playerMovementFeature.Execute();
        _powerUpFeature.Execute();
        _playerFeature.Execute();
        _enemyFeature.Execute();
        _viewFeature.Execute();
    }

    private void LateUpdate()
    {
        _playerInputFeature.Cleanup();
        _playerMovementFeature.Cleanup();
        _powerUpFeature.Cleanup();
        _playerFeature.Cleanup();
        _enemyFeature.Cleanup();
        _viewFeature.Cleanup();
    }
}
