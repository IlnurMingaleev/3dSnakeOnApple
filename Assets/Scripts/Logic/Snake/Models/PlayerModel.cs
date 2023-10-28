using Infrustructure.MVC;
using UniRx;
using UnityEngine;

namespace Logic.Snake
{
    public class PlayerModel: Model
    {
        private float _moveSpeed = 5.0f;
        private float _rotationSpeed = 180.0f;

        public float moveSpeed
        {
            get => _moveSpeed;
        }

        public float rotationSpeed
        {
            get => _rotationSpeed;
        }
        /*private ReactiveProperty<Vector3> _moveVector = new ReactiveProperty<Vector3>();

        private IReadOnlyReactiveProperty<Vector3> moveVector => _moveVector;

        public void SetMoveVector(Vector3 value)
        {
            _moveVector.Value = value;
        }*/
    }
}