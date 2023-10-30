using Logic.Consumables.Views;
using Logic.GravityPhysics;
using Logic.Snake.Controllers;
using Logic.Snake.Views;
using Logic.Tools.Pooling;

namespace Infrustructure.StateMachine.Data
{
    public class DataBetweenStates : IDataBetweenStates
    {
        private IGameObjectPool<IPlayerBodyPartView> _bodyPartsPool;
        private IGameObjectPool<IConsumableView> _consumablesPool;
        private PlayerController _playerController;
        private Planet _planet;
        private IConsumableView _currentConsumable;

        public DataBetweenStates(ref IGameObjectPool<IPlayerBodyPartView> bodyPartsPool,
             ref IGameObjectPool<IConsumableView> consumablesPool,
             ref PlayerController playerController, ref IConsumableView currentConsumable)
        {
            _bodyPartsPool = bodyPartsPool;
            _consumablesPool = consumablesPool;
            _playerController = playerController;
            _currentConsumable = currentConsumable;
        }

        public IGameObjectPool<IPlayerBodyPartView> BodyPartsPool
        {
            get => _bodyPartsPool;
        }

        public IGameObjectPool<IConsumableView> ConsumablesPool
        {
            get => _consumablesPool;
        }

        public PlayerController PlayerController
        {
            get => _playerController;
        }

        public Planet Planet
        {
            get => _planet;
        }

        public IConsumableView CurrentConsumable
        {
            get => _currentConsumable;
        }

        #region Setters

        public void SetBodyPartsPool(IGameObjectPool<IPlayerBodyPartView> bodyPartsPool)
        {
            _bodyPartsPool = bodyPartsPool;
        }
        
        public void SetConsumablesPool(IGameObjectPool<IConsumableView> consumablesPool)
        {
            _consumablesPool = consumablesPool;
        }
        
        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        public void SetPlanet(Planet planet)
        {
            _planet = planet;
        }

        public void SetCurrentConsumable(IConsumableView newConsumable)
        {
            _currentConsumable = newConsumable;
        }

        #endregion
        
        
        
    }
}