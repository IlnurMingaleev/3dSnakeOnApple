using Logic.Consumables.Views;
using Logic.GravityPhysics;
using Logic.Snake.Controllers;
using Logic.Snake.Views;
using Logic.Tools.Pooling;

namespace Infrustructure.StateMachine.Data
{
    public interface IDataBetweenStates
    {
        IGameObjectPool<IPlayerBodyPartView> BodyPartsPool { get; }
        IGameObjectPool<IConsumableView> ConsumablesPool { get; }
        PlayerController PlayerController { get; }
        Planet Planet { get; }
        IConsumableView CurrentConsumable { get; }
        void SetBodyPartsPool(IGameObjectPool<IPlayerBodyPartView> bodyPartsPool);
        void SetConsumablesPool(IGameObjectPool<IConsumableView> consumablesPool);
        void SetPlayerController(PlayerController playerController);
        void SetPlanet(Planet planet);
        void SetCurrentConsumable(IConsumableView newConsumable);
    }
}