using Entitas;
using UnityEngine;

public class EnemySpawnerSystem : IExecuteSystem
{
    private readonly GameContext _gameContext;
    private float _spawnTimer;
    private const float SpawnInterval = 3f;

    public EnemySpawnerSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Execute()
    {
        _spawnTimer += Time.deltaTime;
        
        if (_spawnTimer >= SpawnInterval)
        {
            _spawnTimer = 0f;

            var enemy = _gameContext.CreateEntity();
            enemy.isEnemy = true;
            enemy.AddPosition(new Vector3(UnityEngine.Random.Range(-10f, 10f), 0f, 0f));
            enemy.AddHealth(50);
        }
    }
}