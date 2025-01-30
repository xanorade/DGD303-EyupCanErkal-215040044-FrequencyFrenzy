using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatFeature : Feature
{
    GameContext _gameContext;
    public PlayerCombatFeature(Contexts contexts)
    {
        _gameContext = contexts.game;
        
        Add(new ProjectileShooterSystem(_gameContext));
        Add(new ProjectileMovementSystem(_gameContext));
    }
}
