using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique,GameState]
public class GameRunningComponent : IComponent
{
    public int Value;
}