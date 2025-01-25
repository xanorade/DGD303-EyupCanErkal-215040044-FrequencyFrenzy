using Unity.VisualScripting;

public class ViewFeature : Feature
{
   private GameContext _gameContext;
   
   public ViewFeature(Contexts contexts)
   {
      _gameContext = contexts.game;
      
      Add(new PlayerViewSystem(contexts));
      Add(new ViewPositionUpdaterSystem(contexts));
   }
}
