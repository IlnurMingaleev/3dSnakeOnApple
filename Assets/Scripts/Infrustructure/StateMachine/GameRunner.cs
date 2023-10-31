using System;
using Infrustructure.Factory;
using Infrustructure.StateMachine.Data;
using Logic.Consumables.Views;
using Logic.Snake.Interfaces;
using Logic.Snake.Views;
using Logic.Tools.Pooling;
using UnityEngine;

namespace Infrustructure.StateMachine
{
    public interface IGameRunner
    {
        void Init(IDataBetweenStates dataBetweenStates, IGameObjectFactory gameObjectFactory);
    }

    public class GameRunner : MonoBehaviour, IGameRunner
    {
        private IGameObjectPool<IPlayerBodyPartView> _playerBodyParts;
        private ConsuamablesPool _consumablesPool;
        private IDataBetweenStates _dataBetweenStates;
        private bool _initialized;
        private IGameObjectFactory _gameObjectFactory;

        public void Init(IDataBetweenStates dataBetweenStates, IGameObjectFactory gameObjectFactory)
        {
            _dataBetweenStates = dataBetweenStates;
            _gameObjectFactory = gameObjectFactory;
            _consumablesPool = new ConsuamablesPool(gameObjectFactory,_dataBetweenStates.ConsumablesParentView,_dataBetweenStates.Planet);
            _playerBodyParts = new PlayerBodyPartsPool(_gameObjectFactory, dataBetweenStates.SnakeBodyParent);
            
            Action<IConsumableView> OnConsumed = null;
            OnConsumed = (consumedApple) => { 
                dataBetweenStates.PlayerController
                    .AddBodyPart(_playerBodyParts.Objects,_playerBodyParts);
                _consumablesPool.Get(OnConsumed, consumedApple);
            };
            _consumablesPool.Init(OnConsumed);
            _initialized = true;
        }
        

        private void FixedUpdate()
        {
            if (_initialized)
            {
                
                _dataBetweenStates.PlayerController.FixedUpdate(_playerBodyParts.Objects);
                //_dataBetweenStates.PlayerController.MoveBodyParts(
                //    _playerBodyParts.Objects);
                
            }

            
        }

        private void Update()
        {
            if (_initialized)
            {
                _dataBetweenStates.PlayerController.Update();
            }

            
        }

        
    }
    }