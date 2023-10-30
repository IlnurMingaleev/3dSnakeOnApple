using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Infrustructure.Factory;
using Infrustructure.MVC;
using Infrustructure.Services.Input;
using Logic.Snake.Interfaces;
using Logic.Snake.Views;
using UnityEngine;

namespace Logic.Snake.Controllers
{
    public class PlayerController : Controller,IInitialize
    {
        //private IConsumablesSpawner _consumablesSpawner;
        private IInputService _inputService;
        private Interfaces.IPlayerMovement _playerMovement;
        private IBodyPartsMovement _bodyPartsMovement;

        private PrefabInject _prefabInject;
        
        private Vector3 _moveVector;

        public PlayerController(Models.PlayerModel playerModel, 
            Interfaces.IPlayerMovement playerMovement, IBodyPartsMovement bodyPartsMovement)
        {
            _model = playerModel;
            _inputService = InputService();
            _bodyPartsMovement = bodyPartsMovement;
            _playerMovement = playerMovement;
            

        }

        public void Initialize(View view)
        {
            _view = view;
            _inputService = InputService();
            _moveVector = ((PlayerView) _view).transform.forward;
            
        }

        


        public void FixedUpdate()
        {
            _playerMovement.Look(_view.transform,_moveVector, ((Models.PlayerModel)_model).moveSpeed);
        }

        public void MoveBodyParts(List<IPlayerBodyPartView> playerBodyParts)
        {
            _bodyPartsMovement.Move(((PlayerView)_view).gameObject, playerBodyParts);
        }

        public void Update()
        {
            GatherInput(_inputService);
            _playerMovement.MovePlayer(((Views.PlayerView)_view).Rigidbody,((Views.PlayerView)_view).transform,((Models.PlayerModel)_model).moveSpeed);
        }
        

        private void GatherInput(IInputService inputService)
        {
            //if(_inputService.CanWeCalculateInput())
                _moveVector = new Vector3(inputService.Axis.x, 0, inputService.Axis.y).normalized;
        }

        private static IInputService InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
            {
                MobileInputService mobileInputService = new MobileInputService();
                mobileInputService.InitializeJoystick();
                return mobileInputService;
                
            }
            
        }
        public void AddBodyPart(List<IPlayerBodyPartView> bodyObjects, IPlayerBodyPartView  bodyPart)
        {
            var lastTransform = bodyObjects.Count > 0 ? bodyObjects.Last().Transform : ((PlayerView)_view).transform;
        
            
            bodyPart.Transform.position = lastTransform.position -lastTransform.forward * Constants._distance;
        
            bodyObjects.Add(bodyPart);
        }
        public Transform GetPlayerViewTransform()
        {
            return ((PlayerView) _view).transform;
        }
    }
}