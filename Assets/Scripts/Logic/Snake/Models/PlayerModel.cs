using Infrustructure.MVC;

namespace Logic.Snake.Models
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
    }
}