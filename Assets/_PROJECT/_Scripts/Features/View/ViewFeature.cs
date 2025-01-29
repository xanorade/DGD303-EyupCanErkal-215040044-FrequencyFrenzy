public class ViewFeature : Feature
{
   private readonly GameContext _gameContext;
   
   public ViewFeature(Contexts contexts)
   {
      _gameContext = contexts.game;
      
      Add(new PlayerViewSystem(contexts));
      Add(new ViewPositionUpdaterSystem(contexts));
   }
}
