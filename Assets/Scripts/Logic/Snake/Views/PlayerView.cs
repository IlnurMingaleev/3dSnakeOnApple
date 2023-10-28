using System.Collections.Generic;
using System.Linq;
using Infrustructure.MVC;
using Infrustructure.Services.Input;
using UnityEngine;

namespace Logic.Snake
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : View
    {
        [SerializeField] private List<PlayerBodyPart> _bodyObjects;
        [SerializeField] SnakeBodyParent _prefabsParent;
        [SerializeField] private Rigidbody _rigidbody;
        public SnakeBodyParent prefabsParent
        {
            get => _prefabsParent;
            set => _prefabsParent = value;
        }
        public Rigidbody rigidbody
        {
            get => _rigidbody;
            set => _rigidbody = value;
        }

        public List<PlayerBodyPart> bodyObjects
        {
            get => _bodyObjects;
            private set => _bodyObjects = value;
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            if(!gameObject.activeInHierarchy)
                return;

            rigidbody = _rigidbody;
            prefabsParent = _prefabsParent;
            bodyObjects = _prefabsParent.GetComponentsInChildren<PlayerBodyPart>().ToList();


        }
#endif
        public void OnEnable()
        {
            prefabsParent = FindObjectOfType<SnakeBodyParent>();
            rigidbody = _rigidbody;
            prefabsParent = _prefabsParent;
            bodyObjects = _prefabsParent.GetComponentsInChildren<PlayerBodyPart>().ToList();

        }

        

        
    }
}
