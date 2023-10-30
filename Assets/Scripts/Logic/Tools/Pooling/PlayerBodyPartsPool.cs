using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Infrustructure.Factory;
using Logic.Snake.Controllers;
using Logic.Snake.Views;

namespace Logic.Tools.Pooling
{
    public class PlayerBodyPartsPool: AbstractGameObjectPool<IPlayerBodyPartView>
    {
        private SnakeBodyParent _snakeBodyParent;

        public PlayerBodyPartsPool(IGameObjectFactory gameObjectFactory,PlayerController playerController, SnakeBodyParent snakeBodyParent)
        {
            _gameObjectFactory = gameObjectFactory;
            _snakeBodyParent = snakeBodyParent;
        }

        public override void Return(IPlayerBodyPartView obj, Action OnReturn = null)
        {
            throw new NotImplementedException();
        }

        public override IPlayerBodyPartView Get(Action OnGet = null)
        {
            IPlayerBodyPartView playerBodyPartView = _objects.TryTake(out IPlayerBodyPartView result)
                ? result
                : _gameObjectFactory.Create(AssetPath._snakeBody, 
                    _snakeBodyParent.transform,
                    true).GetComponent<IPlayerBodyPartView>();
            
            return playerBodyPartView;

        }
        
        
    }
}