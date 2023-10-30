using System;
using UnityEngine;

namespace Logic.Consumables.Views
{
    public interface IConsumableView
    {
        public Action ActionOnGet { get;}

        public ConsumablesParentView PrefabsParent
        {
            get;
        }
        public Rigidbody Rigidbody
        {
            get;
        }

        public GravityPhysics.Planet AttractorPlanet
        {
            get;
        }

        public Transform Transform
        {
            get;
        }

        #region Setters

        public void Subscribe(Action actionOnGet);

        #endregion
        public void InitConsumable(GravityPhysics.Planet planet, ConsumablesParentView parent, Action onReturn = null);
    }
}