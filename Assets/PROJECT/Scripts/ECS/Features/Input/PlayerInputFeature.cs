using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputFeature : Feature
{
    private InputContext _inputContext;

    public PlayerInputFeature(Contexts contexts)
    {   
        _inputContext = contexts.input;

        Add(new PlayerInputSystem(_inputContext));
        Add(new ProcessInputSystem(contexts));
    }
}
