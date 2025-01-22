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
        _playerFeature.Initialize();    
    }

    private void Update()
    {
        _playerInputFeature.Execute();
        _playerMovementFeature.Execute();
        _enemyFeature.Execute();
        _powerUpFeature.Execute();
    }

    private void LateUpdate()
    {
        _playerFeature.Cleanup();
    }
}
