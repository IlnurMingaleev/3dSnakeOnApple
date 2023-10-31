using System;
using Logic.GravityPhysics;
using UnityEngine;

namespace Logic.Consumables.Views
{
    public interface IConsumableView
    {
        public Action<IConsumableView> ActionOnGet { get;}

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

        public GameObject GameObject { get; }

        #region Setters

        public void Subscribe(Action<IConsumableView> actionOnGet);

        public void Unsubscribe();

        public void SetAttractorPlanet(Planet planet);
        #endregion
        public void InitConsumable(GravityPhysics.Planet planet, ConsumablesParentView parent, Action<IConsumableView> onReturn = null);
    }
}