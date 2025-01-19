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
            if (!player.hasSpeedBoost)
            {
                player.AddSpeedBoost(1f,5f,false);
                Debug.Log("speeeeeeeeeeeeeeeeed");

            }
            else
            {
                player.ReplaceSpeedBoost(1f, 5f,true);
                Debug.Log("SPEEEEEEEEEEEEEEEEEDDDDD");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.RemoveSpeedBoost();
        }
    }
}
        
    

