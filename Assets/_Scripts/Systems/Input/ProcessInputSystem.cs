using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    private readonly InputContext _inputContext;
    private Vector2 _finalInput;
    
    public ProcessInputSystem(Contexts contexts) : base(contexts.input)
    {
        _inputContext = contexts.input;
    }
    
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AnyOf(
            InputMatcher.HorizontalInput, InputMatcher.VerticalInput).Added());
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> inputs)
    {
        _inputContext.ReplacePlayerInput(
            inputs.Aggregate(Vector2.zero, (current, input) => current + new Vector2(
                input.hasHorizontalInput ? input.horizontalInput.Value : 0f,
                input.hasVerticalInput ? input.verticalInput.Value : 0f
            )).normalized
        );
    }
}