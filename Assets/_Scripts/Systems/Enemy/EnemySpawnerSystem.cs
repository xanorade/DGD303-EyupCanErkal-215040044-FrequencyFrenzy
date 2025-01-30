using Entitas;
using UnityEngine;

public class EnemySpawnerSystem : IExecuteSystem
{
    private readonly GameContext _gameContext;
    private float _spawnTimer;
    private const float SpawnInterval = 3f;
    private int _spawnedEnemies; // Spawn edilen düşman sayısını tutacak sayaç

    public EnemySpawnerSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
        _spawnedEnemies = 0; // Başlangıçta 0 düşman spawn edilmiş
    }

    public void Execute()
    {
        if (_spawnedEnemies >= 10) // 10'dan fazla düşman spawn edilmişse durdur
            return;

        _spawnTimer += Time.deltaTime;
        
        if (_spawnTimer >= SpawnInterval)
        {
            _spawnTimer = 0f;

            // Yeni enemy entity'si oluştur
            GameEntity enemy = _gameContext.CreateEntity();
            enemy.isEnemy = true;
            
            // Spawn pozisyonu belirle
            float spawnZPosition = UnityEngine.Random.Range(5f, 10f);
            float spawnXPosition = UnityEngine.Random.Range(-7f, 7f); // X ekseninde +7 ile -7 arasında rastgele pozisyon

            Vector3 spawnPosition = new Vector3(spawnXPosition, 0f, spawnZPosition);

            // Enemy entity için component'ler ekle
            enemy.AddPosition(spawnPosition);
            enemy.AddHealth(50);
            enemy.AddSpeed(3f);

            // Spawn edilen düşman sayısını artır
            _spawnedEnemies++;
        }
    }
}