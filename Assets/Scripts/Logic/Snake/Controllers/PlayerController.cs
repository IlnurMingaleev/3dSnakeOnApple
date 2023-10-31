using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Infrustructure.Factory;
using Infrustructure.Installers;
using Infrustructure.MVC;
using Infrustructure.Services.Input;
using Logic.GravityPhysics;
using Logic.Snake.Interfaces;
using Logic.Snake.Models;
using Logic.Snake.Views;
using Logic.Tools.Pooling;
using UnityEngine;

namespace Logic.Snake.Controllers
{
    public class PlayerController : Controller,IInitialize
    {
        //private IConsumablesSpawner _consumablesSpawner;
        private IMobileInputService _inputService;
        private IPlayerMovement _playerMovement;
        private IBodyPartsMovement _bodyPartsMovement;
        private Transform _playerMesh;

        private PrefabInject _prefabInject;
        
        private Vector3 _moveVector;

        public PlayerController(Models.PlayerModel playerModel, 
            Interfaces.IPlayerMovement playerMovement, IBodyPartsMovement bodyPartsMovement)
        {
            _model = playerModel;
            _bodyPartsMovement = bodyPartsMovement;
            _playerMovement = playerMovement;
            

        }

        public void Initialize(View view)
        {
            _view = view;
            _inputService = InputService();
            _moveVector = ((PlayerView) _view).transform.forward;
            _playerMesh = ((PlayerView) _view).PlayerMesh;
            
        }

        


        public void FixedUpdate(List<IPlayerBodyPartView> playerBodyParts)
        {
            _playerMovement.MovePlayer(((PlayerView)_view).Rigidbody,
                _playerMesh,
                ((PlayerModel)_model).MoveSpeed);
            MoveBodyParts(playerBodyParts);
        }

        public void MoveBodyParts(List<IPlayerBodyPartView> playerBodyParts)
        {
            _bodyPartsMovement.Move(((PlayerView)_view).gameObject, playerBodyParts);
        }

        public void Update()
        {
            GatherInputAndRotateForward(_inputService);
        }
        

        private void GatherInputAndRotateForward(IMobileInputService inputService)
        {
            if (_inputService.CanWeCalculateInput())
            {
                _moveVector = new Vector3(inputService.Axis.x, 0, inputService.Axis.y).normalized;
                
                RotateForward();
            }

            
        }

        public void RotateForward()
        {
            Transform cameraTransform = UnityEngine.Camera.main.transform;
            if (Math.Abs(cameraTransform.forward.z - (-1)) < 0.02f) return;
        
            Vector3 direction = _moveVector;
        
            // calculate angle and rotation
            float angleDirection = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        
            //camera angle difference
            var camDir = ((PlayerView)_view).transform.InverseTransformDirection(cameraTransform.up);
            float camAngle = Mathf.Atan2(camDir.x,camDir.z) * Mathf.Rad2Deg;
            float angle = camAngle + angleDirection;
        
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        
            // only update rotation if direction greater than zero
            if (_inputService.CanWeCalculateInput())
            {
                _playerMesh.localRotation = targetRotation;
            }
        }

        private static IMobileInputService InputService()
        {
            MobileInputService mobileInputService =  new MobileInputService();
            mobileInputService.InitializeJoystick();
            return mobileInputService;

        }
        public void AddBodyPart(List<IPlayerBodyPartView> bodyObjects,
            IGameObjectPool<IPlayerBodyPartView>  _playerBodyParts)
        {
            var lastTransform = bodyObjects.Count > 0 ? bodyObjects.Last().Transform : ((PlayerView)_view).transform;

            IPlayerBodyPartView bodyPart = _playerBodyParts.Get();

            bodyPart.Transform.position = lastTransform.position -lastTransform.forward * Constants._distance;
        
            bodyObjects.Add(bodyPart);
        }
        public Transform GetPlayerViewTransform()
        {
            return ((PlayerView) _view).transform;
        }
    }
}