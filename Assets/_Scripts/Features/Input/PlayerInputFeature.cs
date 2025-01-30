public class PlayerInputFeature : Feature
{
    private readonly InputContext _inputContext;

    public PlayerInputFeature(Contexts contexts)
    {   
        _inputContext = contexts.input;
        Add(new PlayerInputSystem(_inputContext));
        Add(new ProcessInputSystem(contexts));
    }
}