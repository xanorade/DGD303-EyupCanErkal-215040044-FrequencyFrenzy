using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique, Input]
public class HorizontalInputComponent : IComponent
{
    public float Value;
}
