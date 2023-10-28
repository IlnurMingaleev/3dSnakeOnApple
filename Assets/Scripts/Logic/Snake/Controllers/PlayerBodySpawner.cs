using System.Collections.Generic;
using System.Linq;
using Helpers;
using Infrustructure.Factory;
using Logic.Consumables;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;
namespace Logic.Snake
{
    public class PlayerBodySpawner : IPlayerBodySpawner
    {

        
        private PlayerView _playerView;
        private IBodyPartsMovement _bodyPartsMovement;
        private readonly IGameObjectFactory _gameobjectFactory;

        [Inject]
        public PlayerBodySpawner(IGameObjectFactory gameobjectFactory,  IBodyPartsMovement bodyPartsMovement)
        {
            
            _gameobjectFactory = gameobjectFactory;
            _bodyPartsMovement = bodyPartsMovement;
        }

        public void Initialize(List<PlayerBodyPart> bodyObjects)
        {
            for (int i = 0; i < 3; i++)
            {
                AddBodyPart(bodyObjects);
            }
        }

        

        /*private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                _consumablesSpawner.RandomSpawn();
            }
        }*/


        public void RespawnConsumable(Collision other,List<PlayerBodyPart> bodyObjects, IConsumablesSpawner consumablesSpawner)
        {
            ConsumableView component;
            if (other.gameObject.TryGetComponent(out component))
            {
                Object.Destroy(other.gameObject);
                consumablesSpawner.ReturnConsumable();
                consumablesSpawner.RandomSpawn();
                AddBodyPart(bodyObjects);
            }
        }

        public void AddBodyPart(List<PlayerBodyPart> bodyObjects)
        {
            var lastTransform = bodyObjects.Count > 0 ? bodyObjects.Last().transform : _playerView.transform;
        
            var bodyPart = _gameobjectFactory.Instantiate(AssetPath._snakeBody, _playerView.prefabsParent.transform, true).GetComponent<PlayerBodyPart>();
            bodyPart.transform.position = lastTransform.position -lastTransform.forward * Constants._distance;
        
            bodyObjects.Add(bodyPart);
        }
    }
}

