using UnityEngine;

public class GameCreator : MonoBehaviour
{
    private Contexts _contexts;

    private PlayerInputFeature _playerInputFeature;
    private PlayerFeature _playerFeature;
    private PlayerMovementFeature _playerMovementFeature;
    private PlayerCombatFeature _playerCombatFeature;
    private PowerUpFeature _powerUpFeature;
    private EnemyFeature _enemyFeature;
    private TowerInteractionFeature _towerInteractionFeature;
    private ViewFeature _viewFeature;

    private void Start()
    {
        #region FEATURES
        _playerInputFeature = new PlayerInputFeature(Contexts.sharedInstance);
        _playerFeature = new PlayerFeature(Contexts.sharedInstance);
        _playerMovementFeature = new PlayerMovementFeature(Contexts.sharedInstance);
        _playerCombatFeature = new PlayerCombatFeature(Contexts.sharedInstance);
        _powerUpFeature = new PowerUpFeature(Contexts.sharedInstance);
        _enemyFeature = new EnemyFeature(Contexts.sharedInstance);
        _towerInteractionFeature = new TowerInteractionFeature(Contexts.sharedInstance);
        _viewFeature = new ViewFeature(Contexts.sharedInstance);
        #endregion
        
        #region INITALIZATION
        _playerInputFeature.Initialize();
        _playerFeature.Initialize();
        _playerMovementFeature.Initialize();
        _playerCombatFeature.Initialize();
        _powerUpFeature.Initialize();
        _enemyFeature.Initialize();
        _towerInteractionFeature.Initialize();
        _viewFeature.Initialize();
        #endregion
    }

    private void Update()
    {
        #region EXECUTION
        _playerInputFeature.Execute();
        _playerFeature.Execute();
        _playerMovementFeature.Execute();
        _playerCombatFeature.Execute();
        _powerUpFeature.Execute();
        _enemyFeature.Execute();
        _towerInteractionFeature.Execute();
        _viewFeature.Execute();
        #endregion
    }

    private void LateUpdate()
    {
        #region CLEANUP
        _playerInputFeature.Cleanup();
        _playerFeature.Cleanup();
        _playerMovementFeature.Cleanup();
        //_playerCombatFeature.Cleanup();
        _powerUpFeature.Cleanup();
        _enemyFeature.Cleanup();
        _towerInteractionFeature.Cleanup();
        _viewFeature.Cleanup();
        #endregion
    }
}