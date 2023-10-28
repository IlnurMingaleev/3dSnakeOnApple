using UnityEngine;

namespace Logic.Consumables
{
    public class ConsumablesParentView : MonoBehaviour

    {
        [SerializeField] private Planet.Planet _planet;
        public Planet.Planet planet
        {
            get => _planet;
        }

        public Transform Transform
        {
            get => transform;
        }
    }
}