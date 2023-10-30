using UnityEngine;

namespace Logic.Consumables.Views
{
    public class ConsumablesParentView : MonoBehaviour

    {
        [SerializeField] private GravityPhysics.Planet _planet;
        public GravityPhysics.Planet planet
        {
            get => _planet;
        }

        public Transform Transform
        {
            get => transform;
        }
    }
}