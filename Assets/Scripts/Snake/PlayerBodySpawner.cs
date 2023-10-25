using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class PlayerBodySpawner : MonoBehaviour
    {
        [Header("FoodSpawner")] 
        [SerializeField]
        private FoodSpawner _foodSpawner;
        [Header("Objects")]
        public Transform prefabsParent;
        public PlayerBodyPart bodyPrefab;
        public List<PlayerBodyPart> bodyObjects;

        [Header("Options")] 
        [SerializeField] private float distance = 1;
    
        private void FixedUpdate()
        {
            for (var index = 0; index < bodyObjects.Count; index++)
            {
                var bodyObject = bodyObjects[index];
                var followObject = index-1 >= 0 ? bodyObjects[index-1].gameObject : gameObject;
            
                bodyObject.transform.LookAt(followObject.transform);
                if (Vector3.Distance(bodyObject.transform.position, followObject.transform.position) > distance) 
                    bodyObject._rigidbody.MovePosition(bodyObject._rigidbody.position + bodyObject.transform.forward * (5.0f * Time.fixedDeltaTime));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //AddBodyPart();
                _foodSpawner.RandomSpawn();
            }
        }
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Food"))
            {
                Destroy(other.gameObject);
                _foodSpawner.RandomSpawn();
                AddBodyPart();
            }
        }

        public void AddBodyPart()
        {
            var lastTransform = bodyObjects.Count > 0 ? bodyObjects[^1].transform : transform;
        
            var piece = Instantiate(bodyPrefab, prefabsParent, true);
            piece.transform.position = lastTransform.position -lastTransform.forward * distance;
        
            bodyObjects.Add(piece);
        }
    
    
    }
}
