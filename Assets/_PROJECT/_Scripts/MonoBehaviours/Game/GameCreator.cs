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
    
    private void Start()
    {
        #region FEATURES
        _playerInputFeature = new PlayerInputFeature(Contexts.sharedInstance);
        _playerMovementFeature = new PlayerMovementFeature(Contexts.sharedInstance);
        _powerUpFeature = new PowerUpFeature(Contexts.sharedInstance);
        _playerFeature = new PlayerFeature(Contexts.sharedInstance);
        _enemyFeature = new EnemyFeature(Contexts.sharedInstance);
        _viewFeature = new ViewFeature(Contexts.sharedInstance);
        #endregion
        
        #region INITALIZATION
        _playerInputFeature.Initialize();
        _playerMovementFeature.Initialize();
        _powerUpFeature.Initialize();
        _playerFeature.Initialize();
        _enemyFeature.Initialize();
        _viewFeature.Initialize();
        #endregion
    }

    private void Update()
    {
        #region EXECUTION
        _playerInputFeature.Execute();
        _playerMovementFeature.Execute();
        _powerUpFeature.Execute();
        _playerFeature.Execute();
        _enemyFeature.Execute();
        _viewFeature.Execute();
        #endregion
    }

    private void LateUpdate()
    {
        #region CLEANUP
        _playerInputFeature.Cleanup();
        _playerMovementFeature.Cleanup();
        _powerUpFeature.Cleanup();
        _playerFeature.Cleanup();
        _enemyFeature.Cleanup();
        _viewFeature.Cleanup();
        #endregion
    }
}