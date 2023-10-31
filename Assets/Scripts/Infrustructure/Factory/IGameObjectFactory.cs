using UnityEngine;

namespace Infrustructure.Factory
{
    public interface IGameObjectFactory
    {
        GameObject Create(string path);
        GameObject Create(string path, Transform parent, bool worldPositionStays);
        
        //GameObject Create(string path, )
    }
}