using UnityEngine;

namespace Logic.Snake.Views
{
    public interface IPlayerView
    {
        SnakeBodyParent PrefabsParent { get; }
        Rigidbody Rigidbody { get; }
        GravityPhysics.Planet AttractorPlanet { get; }
        void InitPlayer(GravityPhysics.Planet planet, SnakeBodyParent parent);

        Transform PlayerMesh { get; }
    }
}