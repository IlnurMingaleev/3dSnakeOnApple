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
        private ConsuamablesPool _consumablesPool;
        private PlayerController _playerController;

        public ConsumablesParentView ConsumablesParentView => _consumablesParentView;

        public SnakeBodyParent SnakeBodyParent => _snakeBodyParent;

        private Planet _planet;
        private ConsumablesParentView _consumablesParentView;
        private SnakeBodyParent _snakeBodyParent;
        private IConsumableView _currentConsumable;

        public DataBetweenStates(PlayerController playerController,
            ConsumablesParentView consumablesParentView, SnakeBodyParent snakeBodyParent, Planet planet)
        {
            _consumablesParentView = consumablesParentView;
            _playerController = playerController;
            _snakeBodyParent = snakeBodyParent;
            _planet = planet;

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