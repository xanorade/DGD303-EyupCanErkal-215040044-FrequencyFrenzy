using System;
using Entitas;
using UnityEngine;
using Entitas.Unity;

public class HitDetector : MonoBehaviour
{
    private GameContext _gameContext;
    private EntityLink _link;
    private GameEntity _projectileEntity;
    
    private void Start()
    {
        _gameContext = Contexts.sharedInstance.game;
        _link = GetComponent<EntityLink>();
        _projectileEntity = _link.entity as GameEntity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Triggered");

            // Enemy entity'sini yok et
            EntityLink enemyLink = other.GetComponent<EntityLink>();
            GameEntity enemyEntity = enemyLink?.entity as GameEntity;
            
            
            
            if (enemyEntity != null)
            {
                
                if (!_gameContext.hasEnemyDeathCounter)
                {
                    Debug.Log("yoktu ekledim");
                    _gameContext.ReplaceEnemyDeathCounter(1);
                }
                else
                {
                    Debug.Log("sayac artti");
                    int newCount = _gameContext.enemyDeathCounter.KilledEnemiesCount + 1;
                    _gameContext.ReplaceEnemyDeathCounter(newCount);
                }
                
                enemyEntity.Destroy();
            }
            
            if (enemyLink != null)
            {
                enemyLink.Unlink();
            }
            
            Destroy(other.gameObject); 
            
            
            // Projectile entity'sini yok et
            if (_projectileEntity != null)
            {
                _projectileEntity.Destroy();
            }

            // Projectile GameObject'ini yok et
            Destroy(gameObject);
            
            if (_link != null)
            {
                _link.Unlink();
            }
            
        }
    }
}