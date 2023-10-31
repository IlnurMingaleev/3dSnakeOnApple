using Logic.GravityPhysics;
using UnityEngine;

namespace Logic.Snake.Views
{
    public interface IPlayerBodyPartView
    {
        GameObject GameObject { get; }
        Transform Transform { get; }
        void SetPlayerBodyPartRigidbody(Rigidbody rigidbody);
        Rigidbody Rigidbody { get; }
        public GravityPhysics.Planet AttractorPlanet
        {
            get;
        }

        public void SetAttractorPlanet(Planet planet);

    }
}