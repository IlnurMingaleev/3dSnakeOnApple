using UnityEngine;

namespace Infrustructure.Factory
{
    public interface IGameObjectFactory
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform parent, bool worldPositionStays);
    }
}