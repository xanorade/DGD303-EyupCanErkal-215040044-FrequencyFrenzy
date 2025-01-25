using Entitas;
using UnityEngine;

public class EnemySpawnerSystem : IExecuteSystem
{
    GameContext _gameContext;
    private float _spawnTimer;
    private float _spawnInterval = 3f;

    public EnemySpawnerSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Execute()
    {
        _spawnTimer += Time.deltaTime;
        
        if (_spawnTimer >= _spawnInterval)
        {
            _spawnTimer = 0f;

            var enemy = _gameContext.CreateEntity();
            enemy.isEnemy = true;
            enemy.AddPosition(new Vector3(UnityEngine.Random.Range(-10f, 10f), 0f, 0f));
            enemy.AddHealth(50);
        }
    }
}