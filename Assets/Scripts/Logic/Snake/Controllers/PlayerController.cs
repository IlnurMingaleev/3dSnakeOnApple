using System;
using Infrustructure.Factory;
using Infrustructure.MVC;
using Infrustructure.Services.Input;
using Logic.Consumables;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.PlayerLoop;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Logic.Snake
{
    public class PlayerController : Controller, IDisposable
    {
        private IConsumablesSpawner _consumablesSpawner;
        private IInputService _inputService;
        private IBodyPartsMovement _playerBodyPartsMovement;
        private IPlayerBodySpawner _playerBodySpawner;
        private IPlayerMovement _playerMovement;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private PrefabInject _prefabInject;
        
        private Vector3 _moveVector;

        public PlayerController(PlayerModel playerModel, IBodyPartsMovement playerBodyPartsMovement,
            IPlayerBodySpawner playerBodySpawner, IPlayerMovement playerMovement, PrefabInject prefabInject,
            IConsumablesSpawner consumablesSpawner)
        {
            _model = playerModel;
            _consumablesSpawner = consumablesSpawner;
            _inputService = InputService();
            _playerBodyPartsMovement = playerBodyPartsMovement;
            _playerBodySpawner = playerBodySpawner;
            _playerMovement = playerMovement;
            _prefabInject = prefabInject;

        }
        /*[Inject]
        public void Construct(PlayerModel playerModel, IBodyPartsMovement playerBodyPartsMovement, IPlayerBodySpawner playerBodySpawner, IPlayerMovement playerMovement, PrefabInject prefabInject, IConsumablesSpawner consumablesSpawner)
        {
            _model = playerModel;
            _consumablesSpawner = consumablesSpawner;
            
            _playerBodyPartsMovement =  playerBodyPartsMovement;
            _playerBodySpawner = playerBodySpawner;
            _playerMovement = playerMovement;
            _prefabInject = prefabInject;
            _moveVector = ((PlayerView) _view).transform.forward;
        }*/

        public void Initialize()
        {
            _consumablesSpawner.Initialize();
            _view = Object.FindObjectOfType<PlayerView>().GetComponent<PlayerView>();
            _inputService = InputService();
            _moveVector = ((PlayerView) _view).transform.forward;
            
        }

        public void Start()
        {
            ((PlayerView) _view).gameObject.OnCollisionEnterAsObservable().Subscribe(collision => 
                _playerBodySpawner.RespawnConsumable(collision,((PlayerView)_view).bodyObjects, _consumablesSpawner)).AddTo(_disposable);
        }


        public void FixedUpdate()
        {
            if(((PlayerView)_view).bodyObjects!= null) _playerBodyPartsMovement.Move(((PlayerView)_view).gameObject,((PlayerView)_view).bodyObjects);
            _playerMovement.Look(_view.transform,_moveVector, ((PlayerModel)_model).moveSpeed);
        }

        public void Update()
        {
            GatherInput(_inputService);
            _playerMovement.MovePlayer(((PlayerView)_view).rigidbody,((PlayerView)_view).transform,((PlayerModel)_model).moveSpeed);
        }

        public void Dispose()
        {
            _disposable.Clear();
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
    }
}