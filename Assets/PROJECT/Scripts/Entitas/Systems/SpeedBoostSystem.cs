using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpeedBoostSystem : IExecuteSystem
{
    GameContext _context;

    public SpeedBoostSystem(Contexts context) 
    {
        _context = context.game;
    }
    
    //SPEED BOOST VARKEN BIR TANE DAHA ALIRSAK DURATION ARTACAK SADECE YENI COMPONENT EKLEMEYECEK !! VERIYIOR

    public void Execute()
    {
        GameEntity player = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddSpeedBoost(5f, 5f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.RemoveSpeedBoost();
        }
    }
}
        
    

