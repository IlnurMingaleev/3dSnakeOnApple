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

        public PlayerBodyPartsPool(IGameObjectFactory gameObjectFactory, SnakeBodyParent snakeBodyParent)
        {
            _gameObjectFactory = gameObjectFactory;
            _snakeBodyParent = snakeBodyParent;
        }

        public override IPlayerBodyPartView Get()
        {
            IPlayerBodyPartView playerBodyPartView =  _gameObjectFactory.Create(AssetPath._snakeBody, 
                    _snakeBodyParent.transform,
                    true).GetComponent<IPlayerBodyPartView>();
            _objects.Add(playerBodyPartView);
            return playerBodyPartView;

        }
        
        
    }
}