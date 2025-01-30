using Entitas;
using UnityEngine;

public class PlayerInputSystem : IExecuteSystem
{
    private readonly InputContext _inputContext;
    private float _horizontalInput;
    private float _verticalInput;

    public PlayerInputSystem(InputContext inputContext)
    {
        _inputContext = inputContext;
    }

    public void Execute()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _inputContext.ReplaceVerticalInput(_verticalInput);
        _inputContext.ReplaceHorizontalInput(_horizontalInput);
    }
}