using Entitas;
using UnityEngine;

public class PlayerInputSystem : IExecuteSystem
{
    InputContext _inputContext;
    private float _horizontalInput;
    private float _verticalInput;

    public PlayerInputSystem(InputContext inputContext)
    {
        _inputContext = inputContext;
    }

    public void Execute()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        _inputContext.ReplaceHorizontalInput(_horizontalInput);
        _inputContext.ReplaceVerticalInput(_verticalInput);
        
    }
}
