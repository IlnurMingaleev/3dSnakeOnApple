using Logic.Consumables.Views;
using Logic.GravityPhysics;
using Logic.Snake.Controllers;
using Logic.Snake.Views;
using Logic.Tools.Pooling;

namespace Infrustructure.StateMachine.Data
{
    public interface IDataBetweenStates
    {

        PlayerController PlayerController { get; }
        Planet Planet { get; }
        ConsumablesParentView ConsumablesParentView { get; }
        SnakeBodyParent SnakeBodyParent { get; }

        IConsumableView CurrentConsumable { get; }
        
        void SetPlayerController(PlayerController playerController);
        void SetPlanet(Planet planet);
        void SetCurrentConsumable(IConsumableView newConsumable);
    }
}