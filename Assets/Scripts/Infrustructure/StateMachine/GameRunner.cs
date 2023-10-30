using System;
using Infrustructure.StateMachine.Data;
using UnityEngine;

namespace Infrustructure.StateMachine
{
    public interface IGameRunner
    {
        void Init(IDataBetweenStates dataBetweenStates);
    }

    public class GameRunner : MonoBehaviour, IGameRunner
    {
        private IDataBetweenStates _dataBetweenStates;
        private bool _initialized;

        public void Init(IDataBetweenStates dataBetweenStates)
        {
            _dataBetweenStates = dataBetweenStates;
            _initialized = true;
        }

        private void FixedUpdate()
        {
            if (_initialized)
            {
                _dataBetweenStates.PlayerController.MoveBodyParts(_dataBetweenStates.BodyPartsPool.GetPoolElementsAsList());
                _dataBetweenStates.PlayerController.FixedUpdate();
                
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